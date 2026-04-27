using FluentValidation;
namespace Lms.Application.Features.Course.Validators;
public sealed class CreateCourseValidator : AbstractValidator<string>
{
    public CreateCourseValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
