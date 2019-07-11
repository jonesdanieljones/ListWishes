using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Events
{
    public class UserUpdatedEvent : Event
    {
        public UserUpdatedEvent(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;            
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }        
    }
}