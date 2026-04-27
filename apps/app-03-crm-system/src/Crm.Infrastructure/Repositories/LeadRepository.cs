using Microsoft.EntityFrameworkCore;
using Crm.Application.Abstractions;
using Crm.Domain.Entities;
using Crm.Infrastructure.Persistence;
namespace Crm.Infrastructure.Repositories;
public sealed class LeadRepository(AppDbContext dbContext) : ILeadRepository
{
    public async Task<IReadOnlyList<Lead>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Leads.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Lead> AddAsync(Lead entity, CancellationToken cancellationToken)
    {
        dbContext.Leads.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
