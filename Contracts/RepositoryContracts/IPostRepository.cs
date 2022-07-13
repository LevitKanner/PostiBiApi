using Api.Entities.Models;

namespace Api.Contracts;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllPostsAsync(int userId, bool trackChanges);
    Task<Post> GetPostByIdAsync(int postId, bool trackChanges);
    void DeletePost(int postId);
}