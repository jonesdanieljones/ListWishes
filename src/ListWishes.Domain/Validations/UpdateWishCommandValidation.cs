using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class UpdateWishCommandValidation : WishValidation<UpdateWishCommand>
    {
        public UpdateWishCommandValidation()
        {
            ValidateId();                             
        }
    }
}