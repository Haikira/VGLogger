using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class CreateGameViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public List<PlatformViewModel> Platforms { get; set; }
    }

    public class CreateGameValidator : AbstractValidator<CreateGameViewModel>
    {
        public CreateGameValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty")                
                .MaximumLength(255).WithMessage("Maximum character limit of 255 characters");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description must not be null")
                .NotEmpty().WithMessage("Description must not be empty")
                .MaximumLength(255).WithMessage("Maximum character limit of 255 characters");
        }
    }
}