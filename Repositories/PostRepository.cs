using Api.Contracts.RepositoryContracts;
using Api.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public PostRepository(ApplicationContext context) : base(context)
    {
    }

    public IEnumerable<Post> GetAllPosts(bool trackChanges) =>
        FindAll(trackChanges).OrderBy(post => post.CreatedAt)
            .Include(post => post.User)
            .ToList();


    public IEnumerable<Post> GetUserPosts(string userId, bool trackChanges) =>
        FindByCondition(post => post.UserId == userId, trackChanges)
            .Include(post => post.User)
            .OrderBy(post => post.CreatedAt);

    public Post? GetPost(int postId, bool trackChanges) =>
        FindByCondition(post => post.Id == postId, trackChanges
        ).Include(post => post.User)
            .SingleOrDefault();

    public void CreatePost(string userId, Post post)
    {
        post.UserId = userId;
        Create(post);
    }

    public void UpdatePost(Post post) => Update(post);

    public void DeletePost(Post post) => Delete(post);
}