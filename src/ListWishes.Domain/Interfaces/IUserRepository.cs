using ListWishes.Domain.Models;

namespace ListWishes.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}