using AutoMapper;
using ListWishes.Application.ViewModels;
using ListWishes.Domain.Models;

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
