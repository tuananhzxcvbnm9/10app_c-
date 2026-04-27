using Booking.Domain.Entities;
namespace Booking.Application.Abstractions;
public interface IBookingRepository
{
    Task<IReadOnlyList<Booking>> GetAllAsync(CancellationToken cancellationToken);
    Task<Booking> AddAsync(Booking entity, CancellationToken cancellationToken);
}
