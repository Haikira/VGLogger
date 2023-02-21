using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class UpdateDeveloperViewModel
    {
        public string? Name { get; set; }
    }

    public class UpdateDeveloperValidator : AbstractValidator<UpdateDeveloperViewModel>
    {
        public UpdateDeveloperValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty")
                .MaximumLength(255).WithMessage("Maximum character limit of 255 characters");
        }
    }
}