using Helpdesk.Domain.Entities;
namespace Helpdesk.Application.Abstractions;
public interface ITicketRepository
{
    Task<IReadOnlyList<Ticket>> GetAllAsync(CancellationToken cancellationToken);
    Task<Ticket> AddAsync(Ticket entity, CancellationToken cancellationToken);
}
