using FluentAssertions;
using Lms.Domain.Entities;
using Xunit;

public class CourseTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Course { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
