using Microsoft.EntityFrameworkCore;
using Ecommerce.Application.Abstractions;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence;
namespace Ecommerce.Infrastructure.Repositories;
public sealed class OrderRepository(AppDbContext dbContext) : IOrderRepository
{
    public async Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Orders.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Order> AddAsync(Order entity, CancellationToken cancellationToken)
    {
        dbContext.Orders.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
