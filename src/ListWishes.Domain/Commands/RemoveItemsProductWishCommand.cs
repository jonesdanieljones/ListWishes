using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class RemoveItemsProductWishCommand : ItemsProductWishCommand
    {
        public RemoveItemsProductWishCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveItemProductWishCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}