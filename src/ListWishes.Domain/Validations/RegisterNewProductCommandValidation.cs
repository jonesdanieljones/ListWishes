using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateName();                        
        }
    }
}
