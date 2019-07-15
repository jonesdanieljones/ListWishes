using System;
using ListWishes.Domain.Core.Commands;

namespace ListWishes.Domain.Commands
{
    public abstract class WishCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
    }
}