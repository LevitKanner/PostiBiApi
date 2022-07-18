using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    [ForeignKey(nameof(ApplicationUser))] public string UserId { get; set; }
    public ApplicationUser? User { get; set; }
}