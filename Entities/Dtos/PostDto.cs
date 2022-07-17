namespace Api.Entities.Dtos;

public record PostDto(int Id, string Title, string Content, string CreatedAt,DateTime? UpdatedAt, UserDto User);