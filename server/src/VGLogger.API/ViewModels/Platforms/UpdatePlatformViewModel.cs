using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class UpdatePlatformViewModel
    {
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class UpdatePlatformValidator : AbstractValidator<UpdatePlatformViewModel>
    {
        public UpdatePlatformValidator()
        {
            RuleFor(x => x.Platform)
                .NotNull().WithMessage("Platform must be not null")
                .MaximumLength(255).WithMessage("Platform maximum character limit of 255 characters");
        }
    }
}
