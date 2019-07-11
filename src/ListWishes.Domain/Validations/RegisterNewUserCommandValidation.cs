using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class RegisterNewUserCommandValidation : UserValidation<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidation()
        {
            ValidateName();            
            ValidateEmail();
        }
    }
}
