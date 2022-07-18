using Api.Entities.Models;

namespace Api.Contracts.RepositoryContracts;

public interface IUserRepository
{
    IEnumerable<ApplicationUser> GetAllUsers();
    Task<ApplicationUser?> GetUser(string userId);
    void FollowUser(string userId, string userToFollow);
    void UnFollowUser(UserFollowing following);
    UserFollowing? GetFollowing(string userId, string following);
}