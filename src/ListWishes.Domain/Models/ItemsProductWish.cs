using ListWishes.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Domain.Models
{
    public class ItemsProductWish : Entity
    {
        public ItemsProductWish(Guid id, int productId)
        {
            Id = id;
            ProductId = productId;
        }
        // Empty constructor for EF
        protected ItemsProductWish() { }
        public int WishId { get; set; }
        public int ProductId { get; set; }        
    }
}
