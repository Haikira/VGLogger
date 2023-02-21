using FluentValidation;

namespace VGLogger.API.ViewModels
{
    public class CreateReviewViewModel
    {
        public int StarRating { get; set; }
        public string Description { get; set; }
        public DateTime DateReviewed { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
    }

    public class CreateReviewValidator : AbstractValidator<CreateReviewViewModel>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description must not be null")
                .MaximumLength(2000).WithMessage("Description maximum character limit of 2000 characters");
            RuleFor(x => x.StarRating).GreaterThan(0).LessThanOrEqualTo(5).WithMessage("Star rating must be between 1 and 5");
        }
    }
}
