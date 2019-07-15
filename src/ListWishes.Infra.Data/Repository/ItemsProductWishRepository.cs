using ListWishes.Domain.Interfaces;
using ListWishes.Domain.Models;
using ListWishes.Infra.Data.Context;

namespace ListWishes.Infra.Data.Repository
{
    public class ItemsProductWishRepository : Repository<ItemsProductWish>, IItemsProductWishRepository
    {
        public ItemsProductWishRepository(ListWishesContext context) : base(context)
        {

        }
    }
}
