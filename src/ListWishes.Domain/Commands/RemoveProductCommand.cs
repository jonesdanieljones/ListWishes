using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class RemoveProductCommand : ProductCommand
    {
        public RemoveProductCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}