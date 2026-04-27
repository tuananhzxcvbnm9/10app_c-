using FluentAssertions;
using Blog.Domain.Entities;
using Xunit;

public class PostTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new Post { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
