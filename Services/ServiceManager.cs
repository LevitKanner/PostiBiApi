using Api.Contracts;
using Api.Contracts.ServiceContracts;

namespace Api.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IPostService> _postService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _postService = new Lazy<IPostService>(() => new PostService(repositoryManager));
    }

    public IPostService PostService => _postService.Value;
}