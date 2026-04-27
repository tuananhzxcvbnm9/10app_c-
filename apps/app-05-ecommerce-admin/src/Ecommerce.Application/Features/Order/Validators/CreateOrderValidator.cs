using FluentValidation;
namespace Ecommerce.Application.Features.Order.Validators;
public sealed class CreateOrderValidator : AbstractValidator<string>
{
    public CreateOrderValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
