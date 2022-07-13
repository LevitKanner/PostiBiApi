namespace Api.Entities.Models;

public class ApplicationUser
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public ICollection<Post>? Posts { get; set; }
}