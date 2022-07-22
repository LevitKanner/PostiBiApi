using Api.Contracts;
using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Api.Entities.Exceptions;
using Api.Entities.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Api.Services;

public class PostService : IPostService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public PostService(IRepositoryManager repositoryManager, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _userManager = userManager;
    }

    public IEnumerable<PostDto> GetAllPost(bool trackChanges)
    {
        var posts = _repositoryManager.PostRepository.GetAllPosts(trackChanges);
        return _mapper.Map<IEnumerable<PostDto>>(posts);
    }

    public async Task<IEnumerable<PostDto>> GetUserPosts(string userId, bool trackChanges)
    {
        await FindUser(userId);
        var posts = _repositoryManager.PostRepository.GetUserPosts(userId, trackChanges);
        return _mapper.Map<IEnumerable<PostDto>>(posts);
    }

    private async Task FindUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null) throw new UserNotFoundException($"User with id {userId} not found");
    }

    public PostDto? GetPost(int postId, bool trackChanges)
    {
        var post = _repositoryManager.PostRepository.GetPost(postId, trackChanges);
        if (post is null) throw new PostNotFound($"Post with id {postId} not found in database");
        return _mapper.Map<PostDto>(post);
    }

    public async Task<PostDto> CreatePost(string userId, CreatePostDto createPostDto)
    {
        await FindUser(userId);
        var post = _mapper.Map<Post>(createPostDto);
        _repositoryManager.PostRepository.CreatePost(userId, post);
        _repositoryManager.Save();
        return _mapper.Map<PostDto>(post);
    }

    public void UpdatePost(int postId, UpdatePostDto updatePostDto)
    {
        var post = _repositoryManager.PostRepository.GetPost(postId, true);
        if (post is null) throw new PostNotFound($"Post with id {postId} not found in database");
        post.UpdatedAt = DateTime.UtcNow;
        _mapper.Map(updatePostDto, post);
        _repositoryManager.Save();
    }

    public void DeletePost(int postId)
    {
        var post = _repositoryManager.PostRepository.GetPost(postId, true);
        if (post is null) throw new PostNotFound($"Post with id {postId} not found in database");
        _repositoryManager.PostRepository.DeletePost(post);
        _repositoryManager.Save();
    }

    public IEnumerable<PostDto> GetFollowingPosts(string userId)
    {
        var followings = _repositoryManager.UserRepository.GetUserFollowings(userId);
        var followingPosts = new List<PostDto>();
        if (followings is null) return followingPosts;

        foreach (var id in followings)
        {
            var posts = _repositoryManager.PostRepository.GetUserPosts(id, false);
            followingPosts.AddRange(_mapper.Map<IEnumerable<PostDto>>(posts));
        }

        return followingPosts;
    }
}