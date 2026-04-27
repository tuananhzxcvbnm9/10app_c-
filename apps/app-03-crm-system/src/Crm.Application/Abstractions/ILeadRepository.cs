using Crm.Domain.Entities;
namespace Crm.Application.Abstractions;
public interface ILeadRepository
{
    Task<IReadOnlyList<Lead>> GetAllAsync(CancellationToken cancellationToken);
    Task<Lead> AddAsync(Lead entity, CancellationToken cancellationToken);
}
