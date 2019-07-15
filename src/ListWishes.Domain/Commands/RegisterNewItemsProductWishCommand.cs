using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class RegisterNewItemsProductWishCommand : ItemsProductWishCommand
    {
        public RegisterNewItemsProductWishCommand(Guid productId, Guid wishId)
        {
            ProductId = productId;
            WishId = wishId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewItemsProductWishCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}