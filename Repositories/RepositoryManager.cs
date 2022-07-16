using Api.Contracts;
using Api.Contracts.RepositoryContracts;

namespace Api.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationContext _context;
    private readonly Lazy<IPostRepository> _postRepository;

    public RepositoryManager(ApplicationContext context)
    {
        _context = context;
        _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
    }

    public IPostRepository PostRepository => _postRepository.Value;

    public void Save() => _context.SaveChanges();
}