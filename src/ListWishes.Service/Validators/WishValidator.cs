using FluentValidation;
using ListWishes.Domain.Models;
using System;

namespace ListWishes.Service.Validators
{
    public class WishValidator : AbstractValidator<Wish>
    {
        public WishValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("Is necessary to inform the UserId.")
                .NotNull().WithMessage("Is necessary to inform the UserId.");            
        }
    }
}
