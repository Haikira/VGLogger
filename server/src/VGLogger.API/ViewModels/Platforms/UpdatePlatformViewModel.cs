using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class UpdatePlatformViewModel
    {
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class UpdatePlatformValidator : AbstractValidator<UpdatePlatformViewModel>
    {
        public UpdatePlatformValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(255).WithMessage("Name maximum character limit of 255 characters");
        }
    }
}
