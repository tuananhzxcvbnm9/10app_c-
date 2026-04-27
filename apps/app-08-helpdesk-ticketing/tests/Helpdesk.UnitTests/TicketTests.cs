using FluentAssertions;
using Helpdesk.Domain.Entities;
using Xunit;

public class TicketTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Ticket { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
