using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [ForeignKey(nameof(ApplicationUser))] public int UserId { get; set; }
    public ApplicationUser? User { get; set; }
}