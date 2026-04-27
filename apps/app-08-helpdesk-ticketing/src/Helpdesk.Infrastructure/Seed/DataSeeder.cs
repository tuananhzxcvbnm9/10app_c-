using Helpdesk.Domain.Entities;
using Helpdesk.Infrastructure.Persistence;
namespace Helpdesk.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Tickets.Any()) return;
        db.Tickets.AddRange(new[]
        {
            new Ticket { Name = "Helpdesk Sample A" },
            new Ticket { Name = "Helpdesk Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
