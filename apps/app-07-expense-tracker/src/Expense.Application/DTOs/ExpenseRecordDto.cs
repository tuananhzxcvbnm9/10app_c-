namespace Expense.Application.DTOs;
public sealed record ExpenseRecordDto(Guid Id, string Name, DateTime CreatedAtUtc);
