using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class UpdateDeveloperViewModel
    {
        public string Name { get; set; }
    }

    public class UpdateDeveloperValidator : AbstractValidator<UpdateDeveloperViewModel>
    {
        public UpdateDeveloperValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name must be not null")
                .MaximumLength(255).WithMessage("Maximum character limit of 255 characters");
        }
    }
}