using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class UpdateItemsProductWishCommandValidation : ItemsProductWishValidation<ItemsProductWishCommand>
    {
        public UpdateItemsProductWishCommandValidation()
        {
            ValidateId();                             
        }
    }
}