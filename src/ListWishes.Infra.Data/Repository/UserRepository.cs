using System.Linq;
using ListWishes.Domain.Interfaces;
using ListWishes.Domain.Models;
using ListWishes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ListWishes.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ListWishesContext context) : base(context)
        {

        }

        public User GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
