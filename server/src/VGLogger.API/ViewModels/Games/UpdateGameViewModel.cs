using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class UpdateGameViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public List<PlatformViewModel> Platforms { get; set; }
    }

    public class UpdateGameValidator : AbstractValidator<UpdateGameViewModel>
    {
        public UpdateGameValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(255).WithMessage("Maximum character limit of 255 characters");
        }
    }
}