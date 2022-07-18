using Api.Contracts.RepositoryContracts;

namespace Api.Contracts;

public interface IRepositoryManager
{
    public IPostRepository PostRepository { get; }
    public IUserRepository UserRepository { get; }
    void Save();
}