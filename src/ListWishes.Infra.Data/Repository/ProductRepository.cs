using System.Linq;
using ListWishes.Domain.Interfaces;
using ListWishes.Domain.Models;
using ListWishes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ListWishes.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ListWishesContext context) : base(context)
        {

        }
    }
}
