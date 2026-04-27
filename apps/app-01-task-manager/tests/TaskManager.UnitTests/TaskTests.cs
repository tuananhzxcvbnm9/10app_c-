using FluentAssertions;
using TaskManager.Domain.Entities;
using Xunit;

public class TaskTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Task { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
