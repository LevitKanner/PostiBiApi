using Api.Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Api.Contracts.ServiceContracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(RegisterUserDto userForRegistration);
}