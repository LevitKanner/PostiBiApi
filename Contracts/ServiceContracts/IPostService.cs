using Api.Entities.Dtos;
using Api.Entities.Models;

namespace Api.Contracts.ServiceContracts;

public interface IPostService
{
    IEnumerable<PostDto> GetAllPost(bool trackChanges);
    Task<IEnumerable<PostDto>> GetUserPosts(string userId, bool trackChanges);
    PostDto? GetPost(int postId, bool trackChanges);
    Task<PostDto> CreatePost(string userId, CreatePostDto createPostDto);
    void UpdatePost(int postId, UpdatePostDto updatePostDto);
    void DeletePost(int postId);
    IEnumerable<PostDto> GetFollowingPosts(string userId);
}