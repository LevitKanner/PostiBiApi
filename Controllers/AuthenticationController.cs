using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
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

        var tokens = await _serviceManager.AuthenticationService.CreateToken(true);
        return Ok(new Response(StatusCodes.Status200OK, "Success", tokens));
    }

    [HttpPost]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var newTokens = await _serviceManager.AuthenticationService.RefreshToken(tokenDto);
        return Ok(new Response(StatusCodes.Status200OK, "Success", newTokens));
    }
}