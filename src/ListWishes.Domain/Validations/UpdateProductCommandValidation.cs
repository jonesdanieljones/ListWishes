using ListWishes.Domain.Commands;

namespace ListWishes.Domain.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateName();                        
        }
    }
}