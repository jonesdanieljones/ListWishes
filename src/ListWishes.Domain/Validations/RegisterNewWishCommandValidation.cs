using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class RegisterNewWishCommandValidation : WishValidation<RegisterNewWishCommand>
    {
        public RegisterNewWishCommandValidation()
        {
            ValidateId();                        
        }
    }
}
