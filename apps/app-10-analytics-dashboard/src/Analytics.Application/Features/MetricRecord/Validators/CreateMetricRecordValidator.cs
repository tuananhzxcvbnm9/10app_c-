using FluentValidation;
namespace Analytics.Application.Features.MetricRecord.Validators;
public sealed class CreateMetricRecordValidator : AbstractValidator<string>
{
    public CreateMetricRecordValidator() => RuleFor(x => x).NotEmpty().MaximumLength(200);
}
