namespace Ecommerce.Application.DTOs;
public sealed record OrderDto(Guid Id, string Name, DateTime CreatedAtUtc);
