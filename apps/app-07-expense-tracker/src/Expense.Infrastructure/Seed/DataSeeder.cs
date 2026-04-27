using Expense.Domain.Entities;
using Expense.Infrastructure.Persistence;
namespace Expense.Infrastructure.Seed;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken)
    {
        if (db.ExpenseRecords.Any()) return;
        db.ExpenseRecords.AddRange(new[]
        {
            new ExpenseRecord { Name = "Expense Sample A" },
            new ExpenseRecord { Name = "Expense Sample B" }
        });
        await db.SaveChangesAsync(cancellationToken);
    }
}
