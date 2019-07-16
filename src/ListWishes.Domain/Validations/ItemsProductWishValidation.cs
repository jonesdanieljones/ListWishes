using System;
using ListWishes.Domain.Commands;
using FluentValidation;

namespace ListWishes.Domain.Validations
{
    public abstract class ItemsProductWishValidation<T> : AbstractValidator<T> where T : ItemsProductWishCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }        
    }
}