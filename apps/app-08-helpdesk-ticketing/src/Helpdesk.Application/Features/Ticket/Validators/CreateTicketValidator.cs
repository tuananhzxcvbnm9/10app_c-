using FluentValidation;
namespace Helpdesk.Application.Features.Ticket.Validators;
public sealed class CreateTicketValidator : AbstractValidator<string>
{
    public CreateTicketValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
