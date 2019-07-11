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
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;        
        private readonly IMediatorHandler Bus;

        public UserAppService(IMapper mapper,
                              IUserRepository userRepository,
                              IMediatorHandler bus
                              )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            Bus = bus;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider);
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }

        public void Register(UserViewModel userViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUserCommand>(userViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(UserViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }
        public void Remove(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            Bus.SendCommand(removeCommand);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
