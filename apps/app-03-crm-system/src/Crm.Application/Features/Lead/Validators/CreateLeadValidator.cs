using FluentValidation;
namespace Crm.Application.Features.Lead.Validators;
public sealed class CreateLeadValidator : AbstractValidator<string>
{
    public CreateLeadValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
