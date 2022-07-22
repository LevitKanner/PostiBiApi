using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UsersController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _serviceManager.UserService.GetAllUsers();
        return Ok(new Response(StatusCodes.Status200OK, "Success", users));
    }

    [HttpGet]
    public async Task<IActionResult> GetUser([FromQuery] string userId)
    {
        var user = await _serviceManager.UserService.GetUser(userId);
        return Ok(new Response(StatusCodes.Status200OK, "Success", user));
    }

    [HttpPost]
    public async Task<IActionResult> FollowUser([FromBody] FollowUserDto followUserDto, [FromQuery] string userId)
    {
        await _serviceManager.UserService.FollowUser(userId, followUserDto.userToFollow);
        return Ok(new Response(StatusCodes.Status200OK, "Success", null));
    }

    [HttpDelete]
    public IActionResult UnfollowUser([FromBody] FollowUserDto followUserDto, [FromQuery] string userId)
    {
        _serviceManager.UserService.UnfollowUser(userId, followUserDto.userToFollow);
        return Ok(new Response(StatusCodes.Status200OK, "Success", null));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserFollowers([FromQuery] string userId)
    {
        var followers = await _serviceManager.UserService.GetUserFollowers(userId);
        return Ok(new Response(StatusCodes.Status200OK, "Success", followers));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserFollowing([FromQuery] string userId)
    {
        var followings = await _serviceManager.UserService.GetUserFollowings(userId);
        return Ok(new Response(StatusCodes.Status200OK, "Success", followings));
    }
}