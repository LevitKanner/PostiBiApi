using Api.Entities.Dtos;
using Api.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Api.Contracts.ServiceContracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(RegisterUserDto userForRegistration);
    Task<UserDto?> ValidateUser(UserForAuthenticationDto userForAuth);
    Task<TokenDto> CreateToken(bool populateExp);
    Task<TokenDto> RefreshToken(TokenDto tokens);
}