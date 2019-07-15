using System;
using ListWishes.Domain.Core.Commands;

namespace ListWishes.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }        
    }
}