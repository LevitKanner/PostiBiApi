using Api.Entities.Dtos;
using Api.Entities.Models;

namespace Api.Contracts.ServiceContracts;

public interface IPostService
{
    IEnumerable<Post> GetAllPost(bool trackChanges);
    Task<IEnumerable<PostDto>> GetUserPosts(string userId, bool trackChanges);
    Task<PostDto?> GetPost(string userId, int postId, bool trackChanges);
    Task<PostDto> CreatePost(string userId, CreatePostDto createPostDto);
    Task DeletePost(string userId, int postId);
}