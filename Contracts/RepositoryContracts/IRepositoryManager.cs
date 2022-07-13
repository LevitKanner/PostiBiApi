namespace Api.Contracts;

public interface IRepositoryManager
{
    public IPostRepository PostRepository { get; }
    void Save();
}