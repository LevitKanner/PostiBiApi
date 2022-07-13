using Api.Contracts;

namespace Api.Services;

public class PostService: IPostService
{
    private readonly IRepositoryManager _repositoryManager;

    public PostService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
}