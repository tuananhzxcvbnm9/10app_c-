namespace Inventory.Application.DTOs;
public sealed record ProductDto(Guid Id, string Name, DateTime CreatedAtUtc);
