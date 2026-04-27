using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
namespace Blog.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Posts.Any()) return;
        db.Posts.AddRange(new[]
        {
            new Post { Name = "Blog Sample A" },
            new Post { Name = "Blog Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
