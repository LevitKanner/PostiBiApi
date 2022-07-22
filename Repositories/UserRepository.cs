using Api.Contracts.RepositoryContracts;
using Api.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class UserRepository : RepositoryBase<UserFollowing>, IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationContext _context;

    public UserRepository(UserManager<ApplicationUser> userManager, ApplicationContext context) : base(context)
    {
        _userManager = userManager;
        _context = context;
    }

    public IEnumerable<ApplicationUser> GetAllUsers()
    {
        var users = _userManager.Users.Include(user => user.Posts).ToList();
        return users;
    }

    public async Task<ApplicationUser?> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user;
    }

    public void FollowUser(string userId, string userToFollow)
    {
        Create(new UserFollowing
        {
            UserFollowedId = userToFollow,
            FollowDate = DateTime.UtcNow,
            UserId = userId,
        });
    }

    public void UnFollowUser(UserFollowing following)
    {
        Delete(following);
    }

    public UserFollowing? GetFollowing(string userId, string following)
    {
        return _context.UserFollowings?.FirstOrDefault(userFollowing =>
            userFollowing.UserId.Equals(userId) && userFollowing.UserFollowedId.Equals(following));
    }

    public IEnumerable<string>? GetUserFollowings(string userId)
    {
        return _context.UserFollowings?.Where(uf => uf.UserId.Equals(userId))
            .Select(uf => uf.UserFollowedId)
            .ToList();
    }

    public IEnumerable<string>? GetUserFollowers(string userId)
    {
        return _context.UserFollowings?.Where(uf => uf.UserFollowedId.Equals(userId))
            .Select(uf => uf.UserId)
            .ToList();
    }
}