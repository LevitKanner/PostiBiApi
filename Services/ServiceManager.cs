using Api.Contracts;
using Api.Contracts.ServiceContracts;
using Api.Entities.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Api.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IPostService> _postService;
    private readonly Lazy<IAuthenticationService> _authService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration,
        UserManager<ApplicationUser> userManager)
    {
        _postService = new Lazy<IPostService>(() => new PostService(repositoryManager));
        _authService =
            new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
    }

    public IPostService PostService => _postService.Value;
    public IAuthenticationService AuthenticationService => _authService.Value;
}