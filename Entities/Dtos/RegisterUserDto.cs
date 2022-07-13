using System.ComponentModel.DataAnnotations;

namespace Api.Entities.Dtos;

public class RegisterUserDto
{
    [Required] public string? Username { get; set; }
    [Required] public string? FirstName { get; set; }
    [Required] public string? LastName { get; set; }
    [EmailAddress, Required] public string? Email { get; set; }
    [Required] public string? Password { get; set; }
    [Required, Compare("Password")] public string? ConfirmPassword { get; set; }
}