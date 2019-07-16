using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Events
{
    public class ItemsProductWishRegisteredEvent : Event
    {
        public ItemsProductWishRegisteredEvent(Guid id, Guid? wishId ,Guid? productId)
        {
            Id = id;
            WishId = wishId;
            ProductId = productId;
            
        }
        public Guid Id { get; set; }
        public Guid? WishId { get; set; }
        public Guid? ProductId { get; set; }
                
    }
}