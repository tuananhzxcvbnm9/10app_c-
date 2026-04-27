namespace Blog.Application.DTOs;
public sealed record PostDto(Guid Id, string Name, DateTime CreatedAtUtc);
