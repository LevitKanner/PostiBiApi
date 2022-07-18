using Api.Contracts;
using Api.Contracts.RepositoryContracts;
using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Api.Entities.Exceptions;
using AutoMapper;

namespace Api.Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public IEnumerable<UserDto> GetAllUsers()
    {
        var users = _repositoryManager.UserRepository.GetAllUsers();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto?> GetUser(string userId)
    {
        var user = await _repositoryManager.UserRepository.GetUser(userId);
        if (user is null) throw new UserNotFoundException($"User with id: {userId} does not exist");
        return _mapper.Map<UserDto>(user);
    }

    public async Task FollowUser(string userId, string userToFollow)
    {
        var follower = await _repositoryManager.UserRepository.GetUser(userId);
        if (follower is null)
            throw new UserNotFoundException($"user with id: {userId} does not exist");
        var followee = await _repositoryManager.UserRepository.GetUser(userToFollow);
        if (followee is null)
            throw new UserNotFoundException($"user with id: {userToFollow} does not exist");
        _repositoryManager.UserRepository.FollowUser(userId, userToFollow);
        _repositoryManager.Save();
    }

    public void UnfollowUser(string userId, string userToUnfollow)
    {
        var following = _repositoryManager.UserRepository.GetFollowing(userId, userToUnfollow);
        if (following is null) throw new UserNotFoundException($"User id does not exist in the database");
        _repositoryManager.UserRepository.UnFollowUser(following);
        _repositoryManager.Save();
    }
}