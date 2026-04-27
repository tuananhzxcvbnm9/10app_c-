using FluentAssertions;
using Expense.Domain.Entities;
using Xunit;

public class ExpenseRecordTests
{
    [Fact]
    public void Should_Create_Entity_With_Defaults()
    {
        var entity = new ExpenseRecord { Name = "Demo" };
        entity.Id.Should().NotBeEmpty();
    }
}
