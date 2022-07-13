using Api.Contracts;
using Api.Entities.Models;

namespace Api.Repositories;

public class PostRepository: RepositoryBase<Post>, IPostRepository
{
    public PostRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync(int userId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task<Post> GetPostByIdAsync(int postId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void DeletePost(int postId)
    {
        throw new NotImplementedException();
    }
}