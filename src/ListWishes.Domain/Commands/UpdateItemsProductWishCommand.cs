using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class UpdateItemsProductWishCommand : ItemsProductWishCommand
    {
        public UpdateItemsProductWishCommand(Guid id, string name)
        {
            Id = id;                       
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateItemsProductWishCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}