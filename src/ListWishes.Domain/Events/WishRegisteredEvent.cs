using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Events
{
    public class WishRegisteredEvent : Event
    {
        public WishRegisteredEvent(Guid id, Guid? userId)
        {
            Id = id;
            UserId = userId;         
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public Guid? UserId { get; private set; }     
    }
}