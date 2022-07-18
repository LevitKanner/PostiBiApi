using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/users/{userId}/posts")]
public class PostsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PostsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }


    [HttpGet]
    public async Task<IActionResult> GetUserPostsAsync(string userId)
    {
        var posts = await _serviceManager.PostService.GetUserPosts(userId, false);
        return Ok(new Response(StatusCodes.Status200OK, "Success", posts));
    }

    [HttpGet("{postId:int}")]
    public async Task<IActionResult> GetPostAsync(string userId, int postId)
    {
        var post = _serviceManager.PostService.GetPost(userId, postId, false);
        return Ok(new Response(StatusCodes.Status200OK, "Success", post));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto, string userId)
    {
        var createdPost = await _serviceManager.PostService.CreatePost(userId, createPostDto);
        return Ok(new Response(StatusCodes.Status200OK, "Success", createdPost));
    }

    [HttpPut("{postId:int}")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto updatePostDto, string userId, int postId)
    {
        var post = await _serviceManager.PostService.GetPost(userId, postId, true);
        return Ok();
    }

    [HttpDelete("{postId:int}")]
    public IActionResult DeletePost(string userId, int postId)
    {
        _serviceManager.PostService.DeletePost(userId, postId);
        return NoContent();
    }
}