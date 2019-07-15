using System;
using ListWishes.Domain.Core.Events;

namespace ListWishes.Domain.Events
{
    public class ProductRegisteredEvent : Event
    {
        public ProductRegisteredEvent(Guid id, string name)
        {
            Id = id;
            Name = name;         
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }     
    }
}