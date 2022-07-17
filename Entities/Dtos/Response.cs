namespace Api.Entities.Dtos;

public record Response(int StatusCode, string Message, object Payload);