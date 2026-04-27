using Analytics.Domain.Entities;
namespace Analytics.Application.Abstractions;
public interface IMetricRecordRepository
{
    Task<IReadOnlyList<MetricRecord>> GetAllAsync(CancellationToken cancellationToken);
    Task<MetricRecord> AddAsync(MetricRecord entity, CancellationToken cancellationToken);
}
