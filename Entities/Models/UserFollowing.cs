using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities.Models;

public class UserFollowing
{
    public int Id { get; set; }
    public string? UserFollowedId { get; set; }
    public DateTime? FollowDate { get; set; }
    [ForeignKey(nameof(ApplicationUser))] public string UserId { get; set; }
    public ApplicationUser? User { get; set; }
}