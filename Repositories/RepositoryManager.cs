using Api.Contracts;
using Api.Contracts.RepositoryContracts;
using Api.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Api.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationContext _context;
    private readonly Lazy<IPostRepository> _postRepository;
    private readonly Lazy<IUserRepository> _userRepository;

    public RepositoryManager(ApplicationContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(userManager, context));
    }

    public IPostRepository PostRepository => _postRepository.Value;
    public IUserRepository UserRepository => _userRepository.Value;

    public void Save() => _context.SaveChanges();
}