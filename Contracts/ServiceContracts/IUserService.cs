using Api.Entities.Dtos;

namespace Api.Contracts.ServiceContracts;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers();
    Task<UserDto?> GetUser(string userId);
    Task FollowUser(string userId, string userToFollow);
    void UnfollowUser(string userId, string userToUnfollow);
    Task<IEnumerable<UserDto>> GetUserFollowers(string userId);
    Task<IEnumerable<UserDto>> GetUserFollowings(string userId);
}