using Ecommerce.Domain.Entities;
namespace Ecommerce.Application.Abstractions;
public interface IOrderRepository
{
    Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken cancellationToken);
    Task<Order> AddAsync(Order entity, CancellationToken cancellationToken);
}
