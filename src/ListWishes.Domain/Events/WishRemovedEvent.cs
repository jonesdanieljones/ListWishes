using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Events
{
    public class WishRemovedEvent : Event
    {
        public WishRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}