using Microsoft.EntityFrameworkCore;
using Helpdesk.Application.Abstractions;
using Helpdesk.Domain.Entities;
using Helpdesk.Infrastructure.Persistence;
namespace Helpdesk.Infrastructure.Repositories;
public sealed class TicketRepository(AppDbContext dbContext) : ITicketRepository
{
    public async Task<IReadOnlyList<Ticket>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Tickets.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Ticket> AddAsync(Ticket entity, CancellationToken cancellationToken)
    {
        dbContext.Tickets.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
