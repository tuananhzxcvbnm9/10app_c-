using FluentValidation;
namespace Blog.Application.Features.Post.Validators;
public sealed class CreatePostValidator : AbstractValidator<string>
{
    public CreatePostValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
