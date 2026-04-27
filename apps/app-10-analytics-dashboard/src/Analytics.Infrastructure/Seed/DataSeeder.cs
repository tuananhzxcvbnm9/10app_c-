using Analytics.Domain.Entities;
using Analytics.Infrastructure.Persistence;
namespace Analytics.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.MetricRecords.Any()) return;
        db.MetricRecords.AddRange(new[]
        {
            new MetricRecord { Name = "Analytics Sample A" },
            new MetricRecord { Name = "Analytics Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
