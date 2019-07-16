using System;
using ListWishes.Domain.Core.Events;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class ItemsProductWishUpdateEvent : Event
    {        
  
        public ItemsProductWishUpdateEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public Guid Id { get; private set; }
    }
}