namespace Api.Entities.Exceptions;

public class RefreshTokenBadRequest: BadRequestException 
{
    public RefreshTokenBadRequest(string message) : base(message)
    {
    }
}