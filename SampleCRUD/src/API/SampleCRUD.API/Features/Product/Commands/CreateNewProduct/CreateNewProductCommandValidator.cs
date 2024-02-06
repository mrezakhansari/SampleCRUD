using FluentValidation;

namespace SampleCRUD.API.Features.Product.Commands.CreateNewProduct;

public class CreateNewProductCommandValidator : AbstractValidator<CreateNewProductCommand>
{
    public CreateNewProductCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(c => c.IsAvailable)
            .NotEmpty()
            .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(c => c.ProduceDate)
            .NotEmpty()
            .NotNull().WithMessage("{PropertyName} is required")
            .LessThan(c => DateTime.Now).WithMessage("{PropertyName} cannot be more than today");

        RuleFor(c => c.ManufacturePhone)
            .NotEmpty().NotNull().WithMessage("{PropertyName} is required")
            .MaximumLength(11).WithMessage("{PropertyName} must be 11 characters")
            .MinimumLength(11).WithMessage("{PropertyName} must be 11 characters");

        RuleFor(c => c.ManufactureEmail)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("{PropertyName} is not valid");
    }
}
