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
        if (result.Succeeded) return Ok(new Response(StatusCodes.Status201Created, "Success", null));
        foreach (var error in result.Errors)
        {
            ModelState.TryAddModelError("Errors", error.Description);
        }

        return BadRequest(ModelState);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto credentials)
    {
        if (!await _serviceManager.AuthenticationService.ValidateUser(credentials))
            return Unauthorized();

        var token = await _serviceManager.AuthenticationService.CreateToken();
        return Ok(new Response(StatusCodes.Status200OK, "Success", token));
    }
}