using Crm.Domain.Entities;
using Crm.Infrastructure.Persistence;
namespace Crm.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Leads.Any()) return;
        db.Leads.AddRange(new[]
        {
            new Lead { Name = "Crm Sample A" },
            new Lead { Name = "Crm Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
