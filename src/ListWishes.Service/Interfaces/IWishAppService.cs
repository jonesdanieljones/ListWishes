using ListWishes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Application.Interfaces
{
    public interface IWishAppService : IDisposable
    {
        void Register(WishViewModel wishViewModel);
        IEnumerable<WishViewModel> GetAll();
        WishViewModel GetById(Guid id);
        void Update(WishViewModel wishViewModel);
        void Remove(Guid id);        
    }
}
