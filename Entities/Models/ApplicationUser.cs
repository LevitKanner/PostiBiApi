using Microsoft.AspNetCore.Identity;

namespace Api.Entities.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryDate { get; set; }
    public ICollection<Post>? Posts { get; set; }
    public ICollection<UserFollowing>? UserFollowings { get; set; }
}