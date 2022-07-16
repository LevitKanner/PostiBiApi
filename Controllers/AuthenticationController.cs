using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Api.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthenticationController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        var result = await _serviceManager.AuthenticationService.RegisterUser(registerUserDto);
        if (result.Succeeded) return StatusCode(201);
        foreach (var error in result.Errors)
        {
            ModelState.TryAddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }
}