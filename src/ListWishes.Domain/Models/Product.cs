using ListWishes.Domain.Core.Models;
using System;

namespace ListWishes.Domain.Models
{
    public class Product : Entity
    {
        public Product(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        // Empty constructor for EF
        protected Product() { }        
        public string Name { get; set; }
    }
}
