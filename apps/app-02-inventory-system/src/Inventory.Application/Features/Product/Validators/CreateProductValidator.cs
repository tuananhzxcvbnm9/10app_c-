using FluentValidation;
namespace Inventory.Application.Features.Product.Validators;
public sealed class CreateProductValidator : AbstractValidator<string>
{
    public CreateProductValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
