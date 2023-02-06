using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class CreateDeveloperViewModel
    {
        public string Name { get; set; }
    }

    public class CreateDeveloperValidator : AbstractValidator<CreateDeveloperViewModel>
    {
        public CreateDeveloperValidator()
        {
            RuleFor(rev => rev.Name)
                .NotNull().WithMessage("Name must be not null")
                .MaximumLength(2000).WithMessage("Maximum character limit of 255 characters");
        }
    }
}