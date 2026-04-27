using Lms.Domain.Entities;
using Lms.Infrastructure.Persistence;
namespace Lms.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Courses.Any()) return;
        db.Courses.AddRange(new[]
        {
            new Course { Name = "Lms Sample A" },
            new Course { Name = "Lms Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
