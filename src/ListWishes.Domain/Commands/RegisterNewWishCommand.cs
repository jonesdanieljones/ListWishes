using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class RegisterNewWishCommand : WishCommand
    {
        public RegisterNewWishCommand(Guid userId)
        {
            UserId = userId;                     
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewWishCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}