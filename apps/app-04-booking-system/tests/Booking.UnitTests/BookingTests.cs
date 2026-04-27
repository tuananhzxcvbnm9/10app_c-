using FluentAssertions;
using Booking.Domain.Entities;
using Xunit;

public class BookingTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Booking { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
