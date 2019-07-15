using ListWishes.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ListWishes.Domain.Models
{
    public class Wish : Entity
    {
        public Wish(Guid id, Guid? userId)
        {
            Id = id;
            UserId = userId;
        }
        // Empty constructor for EF
        protected Wish() { }        
        public Guid? UserId { get; set; }
    }
}
