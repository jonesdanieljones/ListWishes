using System;
using ListWishes.Domain.Core.Events;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class ItemsProductWishRemovedEvent : Event
    {
        public Guid WishidId { get; private set; }
      
        public ItemsProductWishRemovedEvent(Guid wishidId, Guid productId)
        {
            WishidId = wishidId;
            AggregateId = productId;
        }
    }
}