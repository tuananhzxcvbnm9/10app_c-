using FluentValidation;
namespace Booking.Application.Features.Booking.Validators;
public sealed class CreateBookingValidator : AbstractValidator<string>
{
    public CreateBookingValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
