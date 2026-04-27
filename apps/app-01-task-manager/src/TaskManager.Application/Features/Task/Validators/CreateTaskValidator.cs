using FluentValidation;
namespace TaskManager.Application.Features.Task.Validators;
public sealed class CreateTaskValidator : AbstractValidator<string>
{
    public CreateTaskValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
