using FluentAssertions;
using Analytics.Domain.Entities;
using Xunit;

public class MetricRecordTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new MetricRecord { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
