using Microsoft.AspNetCore.Identity;

namespace Api.Entities.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ICollection<Post>? Posts { get; set; }
}