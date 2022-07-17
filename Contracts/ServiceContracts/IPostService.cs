using Api.Entities.Dtos;
using Api.Entities.Models;

namespace Api.Contracts.ServiceContracts;

public interface IPostService
{
    IEnumerable<Post> GetAllPost(bool trackChanges);
    IEnumerable<PostDto> GetUserPosts(string userId, bool trackChanges);
    Post? GetPost(string userId, int postId, bool trackChanges);
    Post CreatePost(string userId, CreatePostDto createPostDto);
    void DeletePost(Post post);
}