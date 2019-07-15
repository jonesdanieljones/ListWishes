using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Events
{
    public class WishUpdatedEvent : Event
    {
        public WishUpdatedEvent(Guid id, Guid? userId)
        {
            Id = id;
            UserId = userId;                        
            AggregateId = id;
        }
        public Guid Id { get; set; }                
        public Guid UserId { get; set; }
    }
}