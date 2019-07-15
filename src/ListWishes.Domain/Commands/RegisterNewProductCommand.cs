using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(string name, string email)
        {
            Name = name;                     
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}