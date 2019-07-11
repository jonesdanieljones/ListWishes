using FluentValidation;
using ListWishes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Is necessary to inform the Email.")
                .NotNull().WithMessage("Is necessary to inform the Email.");
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the name.")
                .NotNull().WithMessage("Is necessary to inform the name.");
        }
    }
}
