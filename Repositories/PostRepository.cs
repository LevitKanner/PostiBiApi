using Api.Contracts;
using Api.Contracts.RepositoryContracts;
using Api.Entities.Models;

namespace Api.Repositories;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public PostRepository(ApplicationContext context) : base(context)
    {
    }

    public IEnumerable<Post> GetUserPosts(string userId, bool trackChanges) =>
        FindByCondition(post => post.UserId == userId, trackChanges).OrderBy(post => post.CreatedAt);
    
    public Post? GetPost(string userId, int postId, bool trackChanges) =>
        FindByCondition(post => post.UserId == userId && post.Id == postId, trackChanges).SingleOrDefault();

    public void DeletePost(Post post) => Delete(post);
}