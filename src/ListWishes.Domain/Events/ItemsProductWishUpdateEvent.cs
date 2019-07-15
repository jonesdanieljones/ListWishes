using System;
using ListWishes.Domain.Core.Events;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class ItemsProductWishUpdateEvent : Event
    {
        public Guid Id { get; private set; }
      
        public ItemsProductWishUpdateEvent(Guid wishidId, Guid productId)
        {
            Id = wishidId;
            AggregateId = productId;
        }
    }
}