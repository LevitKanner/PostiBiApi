using Api.Contracts;
using Api.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/users/{userId:int}/posts")]
public class PostsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PostsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostsAsync(int userId)
    {
        return Ok(new {message = userId});
    }
}