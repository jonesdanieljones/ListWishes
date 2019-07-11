using ListWishes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Register(ProductViewModel productViewModel);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
        void Update(ProductViewModel productViewModel);
        void Remove(Guid id);
    }
}
