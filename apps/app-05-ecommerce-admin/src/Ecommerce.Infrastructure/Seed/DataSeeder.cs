using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence;
namespace Ecommerce.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Orders.Any()) return;
        db.Orders.AddRange(new[]
        {
            new Order { Name = "Ecommerce Sample A" },
            new Order { Name = "Ecommerce Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
