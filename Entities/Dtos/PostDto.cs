namespace Api.Entities.Dtos;

public record PostDto(int Id, string Title, string Content, UserDto User);