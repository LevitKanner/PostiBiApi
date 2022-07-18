using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UserController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _serviceManager.UserService.GetAllUsers();
        return Ok(new Response(StatusCodes.Status200OK, "Success", users));
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(string userId)
    {
        var user = await _serviceManager.UserService.GetUser(userId);
        return Ok(new Response(StatusCodes.Status200OK, "Success", user));
    }

    [HttpPost("{userId}/follow")]
    public async Task<IActionResult> FollowUser([FromBody] FollowUserDto followUserDto, string userId)
    {
        await _serviceManager.UserService.FollowUser(userId, followUserDto.userToFollow);
        return Ok(new Response(StatusCodes.Status200OK, "Success", null));
    }

    [HttpDelete("{userId}/unfollow")]
    public IActionResult UnfollowUser([FromBody] FollowUserDto followUserDto, string userId)
    {
        _serviceManager.UserService.UnfollowUser(userId, followUserDto.userToFollow);
        return Ok(new Response(StatusCodes.Status200OK, "Success", null));
    }
}