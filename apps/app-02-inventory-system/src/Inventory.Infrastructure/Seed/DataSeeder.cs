using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persistence;
namespace Inventory.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Products.Any()) return;
        db.Products.AddRange(new[]
        {
            new Product { Name = "Inventory Sample A" },
            new Product { Name = "Inventory Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
