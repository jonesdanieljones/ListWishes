using ListWishes.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Domain.Models
{
    public class ItemsProductWish : Entity
    {
        public ItemsProductWish(Guid id, Guid productId, Guid wishId)
        {
            Id = id;
            ProductId = productId;
            WishId = wishId;
        }      
        // Empty constructor for EF
        protected ItemsProductWish() { }           
        public Guid? ProductId { get; private set; }
        public Guid? WishId { get; private set; }
        public virtual Product Product { get; private set; }
    }
}
