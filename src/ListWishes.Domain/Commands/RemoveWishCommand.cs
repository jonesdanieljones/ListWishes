using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class RemoveWishCommand : WishCommand
    {
        public RemoveWishCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveWishCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}