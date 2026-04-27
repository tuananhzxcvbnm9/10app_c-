using FluentAssertions;
using Ecommerce.Domain.Entities;
using Xunit;

public class OrderTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Order { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
