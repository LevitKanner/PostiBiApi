using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PostsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public IActionResult GetAllPosts()
    {
        var posts = _serviceManager.PostService.GetAllPost(false);
        return Ok(new Response(StatusCodes.Status200OK, "Success", posts));
    }

    [HttpGet("user-posts/{userId}")]
    public async Task<IActionResult> GetUserPostsAsync(string userId)
    {
        var posts = await _serviceManager.PostService.GetUserPosts(userId, false);
        return Ok(new Response(StatusCodes.Status200OK, "Success", posts));
    }

    [HttpGet("{postId:int}")]
    public IActionResult GetPostAsync(int postId)
    {
        var post = _serviceManager.PostService.GetPost(postId, false);
        return Ok(new Response(StatusCodes.Status200OK, "Success", post));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto, [FromQuery] string userId)
    {
        var createdPost = await _serviceManager.PostService.CreatePost(userId, createPostDto);
        return Ok(new Response(StatusCodes.Status200OK, "Success", createdPost));
    }

    [HttpPut("{postId:int}")]
    public IActionResult UpdatePost([FromBody] UpdatePostDto updatePostDto, int postId)
    {
        _serviceManager.PostService.UpdatePost(postId, updatePostDto);
        return Ok(new Response(StatusCodes.Status200OK, "Success", null));
    }

    [HttpDelete("{postId:int}")]
    public IActionResult DeletePost(int postId)
    {
        _serviceManager.PostService.DeletePost(postId);
        return Ok(new Response(StatusCodes.Status204NoContent, "Success", null));
    }

    [HttpGet("user-following/{userId}")]
    public IActionResult GetFollowingPosts(string userId)
    {
        var posts = _serviceManager.PostService.GetFollowingPosts(userId);
        return Ok(new Response(StatusCodes.Status200OK, "Success", posts));
    }
}