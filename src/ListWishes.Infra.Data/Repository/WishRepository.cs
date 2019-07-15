using ListWishes.Domain.Interfaces;
using ListWishes.Domain.Models;
using ListWishes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Infra.Data.Repository
{
    public class WishRepository : Repository<Wish>, IWishRepository    
    {
        public WishRepository(ListWishesContext context) : base(context)
        {

        }
    }
}
