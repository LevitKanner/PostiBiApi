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

    public async Task<IEnumerable<UserDto>> GetUserFollowers(string userId)
    {
        var followers = _repositoryManager.UserRepository.GetUserFollowers(userId);
        var followersList = new List<UserDto>();

        if (followers is null) return followersList;
        foreach (var id in followers)
        {
            var user = await _repositoryManager.UserRepository.GetUser(id);
            followersList.Add(_mapper.Map<UserDto>(user));
        }

        return followersList;
    }

    public async Task<IEnumerable<UserDto>> GetUserFollowings(string userId)
    {
        var followings = _repositoryManager.UserRepository.GetUserFollowings(userId);
        var followingList = new List<UserDto>();

        if (followings is null) return followingList;
        foreach (var id in followings)
        {
            var user = await _repositoryManager.UserRepository.GetUser(id);
            followingList.Add(_mapper.Map<UserDto>(user));
        }

        return followingList;
    }
}