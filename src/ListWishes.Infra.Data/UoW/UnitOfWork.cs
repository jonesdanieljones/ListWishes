using ListWishes.Domain.Interfaces;
using ListWishes.Infra.Data.Context;

namespace ListWishes.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ListWishesContext _context;

        public UnitOfWork(ListWishesContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
