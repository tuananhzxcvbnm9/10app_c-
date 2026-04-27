using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistence;
namespace TaskManager.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Tasks.Any()) return;
        db.Tasks.AddRange(new[]
        {
            new Task { Name = "TaskManager Sample A" },
            new Task { Name = "TaskManager Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
