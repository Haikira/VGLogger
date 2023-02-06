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
            RuleFor(rev => rev.Name)
                .NotNull().WithMessage("Name must be not null")
                .MaximumLength(2000).WithMessage("Maximum character limit of 255 characters");
        }
    }
}