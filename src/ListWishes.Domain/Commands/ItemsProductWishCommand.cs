using System;
using ListWishes.Domain.Core.Commands;

namespace ListWishes.Domain.Commands
{
    public abstract class ItemsProductWishCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid WishId { get; protected set; }
        public Guid ProductId { get; protected set; }            
    }
}