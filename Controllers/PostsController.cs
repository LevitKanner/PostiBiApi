using Api.Contracts.ServiceContracts;
using Api.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
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

    [HttpGet]
    public async Task<IActionResult> GetUserPostsAsync([FromQuery] string userId)
    {
        var posts = await _serviceManager.PostService.GetUserPosts(userId, false);
        return Ok(new Response(StatusCodes.Status200OK, "Success", posts));
    }

    [HttpGet]
    public IActionResult GetPostAsync([FromQuery] int postId)
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

    [HttpPut]
    public IActionResult UpdatePost([FromBody] UpdatePostDto updatePostDto,
        [FromQuery] int postId)
    {
        _serviceManager.PostService.UpdatePost(postId, updatePostDto);
        return Ok(new Response(StatusCodes.Status200OK, "Success", null));
    }

    [HttpDelete]
    public IActionResult DeletePost([FromQuery] int postId)
    {
        _serviceManager.PostService.DeletePost(postId);
        return Ok(new Response(StatusCodes.Status204NoContent, "Success", null));
    }

    [HttpGet]
    public IActionResult GetFollowingPosts(string userId)
    {
        var posts = _serviceManager.PostService.GetFollowingPosts(userId);
        return Ok(new Response(StatusCodes.Status200OK, "Success", posts));
    }
}