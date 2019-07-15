using AutoMapper;
using AutoMapper.QueryableExtensions;
using ListWishes.Application.Interfaces;
using ListWishes.Application.ViewModels;
using ListWishes.Domain.Commands;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ListWishes.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;        
        private readonly IMediatorHandler Bus;

        public ProductAppService(IMapper mapper,
                              IProductRepository productRepository,
                              IMediatorHandler bus
                              )
        {
            _mapper = mapper;
            _productRepository = productRepository;
            Bus = bus;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _productRepository.GetAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public void Register(ProductViewModel productViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(productViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            Bus.SendCommand(updateCommand);
        }
        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            Bus.SendCommand(removeCommand);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
