using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Eventos.Events
{
    public class ItemsProductWishAddEvent : Event
    {
        public Guid Id { get; private set; }
    
        public ItemsProductWishAddEvent(Guid wishId, Guid productId)
        {
            Id = wishId;            
            AggregateId = productId;
        }
    }
}