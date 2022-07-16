using Api.Entities.Models;

namespace Api.Contracts.RepositoryContracts;

public interface IPostRepository
{
    IEnumerable<Post> GetUserPosts(string userId, bool trackChanges);
    Post? GetPost(string userId, int postId, bool trackChanges);
    void DeletePost(Post post);
}