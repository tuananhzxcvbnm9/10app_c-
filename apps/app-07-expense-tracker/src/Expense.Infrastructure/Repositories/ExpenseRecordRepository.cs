using Microsoft.EntityFrameworkCore;
using Expense.Application.Abstractions;
using Expense.Domain.Entities;
using Expense.Infrastructure.Persistence;
namespace Expense.Infrastructure.Repositories;
public sealed class ExpenseRecordRepository(AppDbContext dbContext) : IExpenseRecordRepository
{
    public async Task<IReadOnlyList<ExpenseRecord>> GetAllAsync(CancellationToken cancellationToken) =>
        await dbContext.ExpenseRecords.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);

    public async Task<ExpenseRecord> AddAsync(ExpenseRecord entity, CancellationToken cancellationToken)
    {
        dbContext.ExpenseRecords.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
