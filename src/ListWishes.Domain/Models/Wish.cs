using ListWishes.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ListWishes.Domain.Models
{
    public class Wish : Entity
    {
        public Wish(Guid id, int userId)
        {
            Id = id;
            UserId = userId;
        }
        // Empty constructor for EF
        protected Wish() { }
        public int UserId { get; set; }
        public List<Product> ListProduct { get; set; }
    }
}
