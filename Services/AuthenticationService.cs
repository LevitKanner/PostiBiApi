using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Api.Entities.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Api.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService(IMapper mapper,
        UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUser(RegisterUserDto userForRegistration)
    {
        var user = _mapper.Map<ApplicationUser>(userForRegistration);
        var result = await _userManager.CreateAsync(user,
            userForRegistration.Password);
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(user, "User");
        return result;
    }
}