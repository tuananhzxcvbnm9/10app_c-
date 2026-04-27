using FluentAssertions;
using Inventory.Domain.Entities;
using Xunit;

public class ProductTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Product { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
