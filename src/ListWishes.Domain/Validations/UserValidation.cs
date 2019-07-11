using System;
using ListWishes.Domain.Commands;
using FluentValidation;

namespace ListWishes.Domain.Validations
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
       
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }        
    }
}