using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Events
{
    public class UserRemovedEvent : Event
    {
        public UserRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}