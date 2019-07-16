using ListWishes.Domain.Core.Models;
using System;

namespace ListWishes.Domain.Models
{
    public class ItemsProductWish : Entity
    {
        public ItemsProductWish(Guid id, Guid? wishId, Guid? productId)
        {
            Id = id;            
            WishId = wishId;
            ProductId = productId;
        }      
        // Empty constructor for EF
        protected ItemsProductWish() { }
        public Guid? WishId { get; private set; }
        public Guid? ProductId { get; private set; }        
        public virtual Product Product { get; private set; }
    }
}
