using System;
using ListWishes.Domain.Commands;
using FluentValidation;

namespace ListWishes.Domain.Validations
{
    public abstract class WishValidation<T> : AbstractValidator<T> where T : WishCommand
    {         
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
            RuleFor(c => c.UserId)
                .NotEqual(Guid.Empty);
        }        
    }
}