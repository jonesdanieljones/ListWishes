using FluentValidation;
using ListWishes.Domain.Models;
using System;

namespace ListWishes.Service.Validators
{
    public class ItemsProductWishValidator : AbstractValidator<ItemsProductWish>
    {
        public ItemsProductWishValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });
            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("Is necessary to inform ProductId.")
                .NotNull().WithMessage("Is necessary to inform the ProductId.");
            RuleFor(c => c.WishId)
                .NotEmpty().WithMessage("Is necessary to inform WishId.")
                .NotNull().WithMessage("Is necessary to inform the WishId.");
        }
    }
}
