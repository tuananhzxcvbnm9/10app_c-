using Microsoft.EntityFrameworkCore;
using Inventory.Application.Abstractions;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persistence;
namespace Inventory.Infrastructure.Repositories;
public sealed class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Products.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Product> AddAsync(Product entity, CancellationToken cancellationToken)
    {
        dbContext.Products.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
