namespace Helpdesk.Application.DTOs;
public sealed record TicketDto(Guid Id, string Name, DateTime CreatedAtUtc);
