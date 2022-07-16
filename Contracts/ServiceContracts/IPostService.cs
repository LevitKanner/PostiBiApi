using Api.Entities.Models;

namespace Api.Contracts.ServiceContracts;

public interface IPostService
{
    IEnumerable<Post> GetUserPosts(string userId, bool trackChanges);
    Post? GetPost(string userId, int postId, bool trackChanges);
}