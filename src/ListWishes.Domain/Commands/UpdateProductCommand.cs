using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string name)
        {
            Id = id;
            Name = name;            
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}