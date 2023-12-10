using CleanArchitecture.Prover.Web.Models;
using FluentValidation;

namespace CleanArchitecture.Prover.Web.Validators;

public sealed class CreatePrøveModelValidator : AbstractValidator<CreatePrøveModel>
{
    public CreatePrøveModelValidator()
    {
        RuleFor(model => model.Trinn).InclusiveBetween(1, 10).WithMessage("Trinn must be between 1 and 10");
        RuleFor(model => model.Fra).LessThan(model => model.Til).WithMessage("Fra must be before Til");
    }
}