using Inventory.Domain.Entities;
namespace Inventory.Application.Abstractions;
public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task<Product> AddAsync(Product entity, CancellationToken cancellationToken);
}
