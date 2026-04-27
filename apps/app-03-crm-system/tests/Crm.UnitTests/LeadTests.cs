using FluentAssertions;
using Crm.Domain.Entities;
using Xunit;

public class LeadTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Lead { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
