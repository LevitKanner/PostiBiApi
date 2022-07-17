using Api.Contracts;
using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Api.Entities.Models;
using AutoMapper;

namespace Api.Services;

public class PostService : IPostService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public PostService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public IEnumerable<Post> GetAllPost(bool trackChanges)
    {
        var posts = _repositoryManager.PostRepository.GetAllPosts(trackChanges);
        return posts;
    }

    public IEnumerable<PostDto> GetUserPosts(string userId, bool trackChanges)
    {
        var posts = _repositoryManager.PostRepository.GetUserPosts(userId, trackChanges);
        return _mapper.Map<IEnumerable<PostDto>>(posts);
    }

    public Post? GetPost(string userId, int postId, bool trackChanges)
    {
        var post = _repositoryManager.PostRepository.GetPost(userId, postId, trackChanges);
        return post;
    }

    public Post CreatePost(string userId, CreatePostDto createPostDto)
    {
        var post = _mapper.Map<Post>(createPostDto);
        _repositoryManager.PostRepository.CreatePost(userId, post);
        _repositoryManager.Save();
        return post;
    }

    public void DeletePost(Post post)
    {
        _repositoryManager.PostRepository.DeletePost(post);
        _repositoryManager.Save();
    }
}