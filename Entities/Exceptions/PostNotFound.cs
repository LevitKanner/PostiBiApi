namespace Api.Entities.Exceptions;

public sealed class PostNotFound : NotFoundException
{
    public PostNotFound(string message) : base(message)
    {
    }
}