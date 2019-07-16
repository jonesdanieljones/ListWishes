using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class RemoveItemProductWishCommandValidation : ItemsProductWishValidation<RemoveItemsProductWishCommand>
    {
        public RemoveItemProductWishCommandValidation()
        {
            ValidateId();
        }
    }
}