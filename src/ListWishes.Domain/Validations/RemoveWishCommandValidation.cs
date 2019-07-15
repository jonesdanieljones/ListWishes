using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class RemoveWishCommandValidation : WishValidation<RemoveWishCommand>
    {
        public RemoveWishCommandValidation()
        {
            ValidateId();
        }
    }
}