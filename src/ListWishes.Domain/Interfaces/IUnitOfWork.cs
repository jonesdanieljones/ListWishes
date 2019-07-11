using System;

namespace ListWishes.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
