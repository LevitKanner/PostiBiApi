using Api.Entities.Models;

namespace Api.Contracts.RepositoryContracts;

public interface IPostRepository
{
    IEnumerable<Post> GetAllPosts(bool trackChanges);
    IEnumerable<Post> GetUserPosts(string userId, bool trackChanges);
    Post? GetPost(string userId, int postId, bool trackChanges);
    void CreatePost(string userId, Post post);
    void UpdatePost(Post post);
    void DeletePost(Post post);
}