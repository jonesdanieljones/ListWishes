using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class UpdateWishCommand : WishCommand
    {
        public UpdateWishCommand(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;            
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateWishCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}