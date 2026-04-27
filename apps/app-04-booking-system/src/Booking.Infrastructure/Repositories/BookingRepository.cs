using Microsoft.EntityFrameworkCore;
using Booking.Application.Abstractions;
using Booking.Domain.Entities;
using Booking.Infrastructure.Persistence;
namespace Booking.Infrastructure.Repositories;
public sealed class BookingRepository(AppDbContext dbContext) : IBookingRepository
{
    public async Task<IReadOnlyList<Booking>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.Bookings.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<Booking> AddAsync(Booking entity, CancellationToken cancellationToken)
    {
        dbContext.Bookings.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
