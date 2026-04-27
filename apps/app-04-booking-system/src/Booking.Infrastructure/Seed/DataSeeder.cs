using Booking.Domain.Entities;
using Booking.Infrastructure.Persistence;
namespace Booking.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.Bookings.Any()) return;
        db.Bookings.AddRange(new[]
        {
            new Booking { Name = "Booking Sample A" },
            new Booking { Name = "Booking Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
