using Api.Entities.Dtos;

namespace Api.Contracts.ServiceContracts;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers();
    UserDto? GetUser(string userId);
    Task FollowUser(string userId, string userToFollow);
    void UnfollowUser(string userId, string userToUnfollow);
}