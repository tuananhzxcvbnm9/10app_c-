using Expense.Domain.Entities;
namespace Expense.Application.Abstractions;
public interface IExpenseRecordRepository
{
    Task<IReadOnlyList<ExpenseRecord>> GetAllAsync(CancellationToken cancellationToken);
    Task<ExpenseRecord> AddAsync(ExpenseRecord entity, CancellationToken cancellationToken);
}
