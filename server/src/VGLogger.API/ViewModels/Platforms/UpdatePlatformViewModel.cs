﻿using FluentValidation;

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
            RuleFor(rev => rev.Platform)
                .NotNull().WithMessage("Name must be not null")
                .MaximumLength(2000).WithMessage("Maximum character limit of 255 characters");
        }
    }
}
