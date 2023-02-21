using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class CreatePlatformViewModel
    {
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class CreatePlatformValidator : AbstractValidator<CreatePlatformViewModel>
    {
        public CreatePlatformValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(255).WithMessage("Name maximum character limit of 255 characters");
        }
    }
}
