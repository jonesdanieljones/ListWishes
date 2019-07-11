using System;
using ListWishes.Domain.Core.Models;

namespace ListWishes.Domain.Models
{
    public class User : Entity
    {
        public User(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;            
        }

        // Empty constructor for EF
        protected User() { }
        public string Name { get; private set; }
        public string Email { get; private set; }
        
    }
}