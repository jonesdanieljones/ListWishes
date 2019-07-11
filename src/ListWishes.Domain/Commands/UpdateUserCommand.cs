using System;
using ListWishes.Domain.Validations;

namespace ListWishes.Domain.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;            
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}