using AutoMapper;
using ListWishes.Application.ViewModels;
using ListWishes.Domain.Commands;

namespace ListWishes.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, RegisterNewUserCommand>()
                .ConstructUsing(c => new RegisterNewUserCommand(c.Name, c.Email));
            CreateMap<UserViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.Name, c.Email));
        }
    }
}
