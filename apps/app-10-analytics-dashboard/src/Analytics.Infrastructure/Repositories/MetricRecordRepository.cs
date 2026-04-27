using Microsoft.EntityFrameworkCore;
using Analytics.Application.Abstractions;
using Analytics.Domain.Entities;
using Analytics.Infrastructure.Persistence;
namespace Analytics.Infrastructure.Repositories;
public sealed class MetricRecordRepository(AppDbContext dbContext) : IMetricRecordRepository
{
    public async Task<IReadOnlyList<MetricRecord>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.MetricRecords.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<MetricRecord> AddAsync(MetricRecord entity, CancellationToken cancellationToken)
    {
        dbContext.MetricRecords.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
