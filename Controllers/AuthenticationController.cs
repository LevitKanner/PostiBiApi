using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth/[action]")]
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
        var errors = result.Errors.Select(error => error.Description).ToList();
        return BadRequest(errors);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto credentials)
    {
        var user = await _serviceManager.AuthenticationService.ValidateUser(credentials);
        if (user is null)
            return Unauthorized(new Response(StatusCodes.Status401Unauthorized, "Incorrect username or password",
                null));

        var tokens = await _serviceManager.AuthenticationService.CreateToken(true);
        Response.Cookies.Append("refresh-token", tokens.RefreshToken, new CookieOptions
        {
            Secure = true,
            SameSite = SameSiteMode.None,
            HttpOnly = true
        });
        return Ok(new Response(StatusCodes.Status200OK, "Success", new { tokens, user }));
    }

    [HttpPost]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var newTokens = await _serviceManager.AuthenticationService.RefreshToken(tokenDto);
        return Ok(new Response(StatusCodes.Status200OK, "Success", newTokens));
    }
}