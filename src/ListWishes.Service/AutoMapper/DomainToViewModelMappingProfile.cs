using AutoMapper;
using ListWishes.Application.ViewModels;
using ListWishes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Wish, WishViewModel>();
            CreateMap<ItemsProductWish, ItemsProductViewModel>();
            
        }
    }
}
