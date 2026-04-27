namespace TaskManager.Application.DTOs;
public sealed record TaskDto(Guid Id, string Name, DateTime CreatedAtUtc);
