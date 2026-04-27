using FluentValidation;
namespace Expense.Application.Features.ExpenseRecord.Validators;
public sealed class CreateExpenseRecordValidator : AbstractValidator<string>
{
    public CreateExpenseRecordValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
