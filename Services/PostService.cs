using Api.Contracts;
using Api.Contracts.ServiceContracts;
using Api.Entities.Models;

namespace Api.Services;

public class PostService: IPostService
{
    private readonly IRepositoryManager _repositoryManager;

    public PostService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public IEnumerable<Post> GetUserPosts(string userId, bool trackChanges)
    {
        var posts = _repositoryManager.PostRepository.GetUserPosts(userId, trackChanges);
        return posts;
    }

    public Post? GetPost(string userId, int postId, bool trackChanges)
    {
        var post = _repositoryManager.PostRepository.GetPost(userId, postId, trackChanges);
        return post;
    }
}