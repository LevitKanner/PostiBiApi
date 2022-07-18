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

    public IEnumerable<Post> GetAllPost(bool trackChanges)
    {
        var posts = _repositoryManager.PostRepository.GetAllPosts(trackChanges);
        return posts;
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

    public async Task<PostDto?> GetPost(string userId, int postId, bool trackChanges)
    {
        await FindUser(userId);
        var post = _repositoryManager.PostRepository.GetPost(userId, postId, trackChanges);
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

    public async Task DeletePost(string userId, int postId)
    {
        await FindUser(userId);
        var post = _repositoryManager.PostRepository.GetPost(userId, postId, true);
        if (post is null) throw new PostNotFound($"Post with id {postId} not found in database");
        _repositoryManager.PostRepository.DeletePost(post);
        _repositoryManager.Save();
    }
}