using ListWishes.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Domain.Validations
{
    public class RegisterNewItemsProductWishCommandValidation : ItemsProductWishValidation<RegisterNewItemsProductWishCommand>
    {
        public RegisterNewItemsProductWishCommandValidation()
        {
            ValidateId();
        }
    }
}
