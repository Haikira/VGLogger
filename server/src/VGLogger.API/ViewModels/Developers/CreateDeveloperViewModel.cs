using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class CreateDeveloperViewModel
    {
        public string? Name { get; set; }
    }

    public class CreateDeveloperValidator : AbstractValidator<CreateDeveloperViewModel>
    {
        public CreateDeveloperValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty")
                .MaximumLength(255).WithMessage("Maximum character limit of 255 characters");
        }
    }
}