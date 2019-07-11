using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
        }
    }
}