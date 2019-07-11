using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateId();
            ValidateName();            
            ValidateEmail();
        }
    }
}