using ListWishes.Application.Interfaces;
using ListWishes.Application.ViewModels;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListWishes.Application.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserAppService _userAppService;

        public UserController(
            IUserAppService userAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("user")]
        public IActionResult Get()
        {
            return Response(_userAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("user/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var userViewModel = _userAppService.GetById(id);

            return Response(userViewModel);
        }

        [HttpPost]
        [Route("user")]
        public IActionResult Post([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userViewModel);
            }

            _userAppService.Register(userViewModel);

            return Response(userViewModel);
        }

        [HttpPut]        
        [Route("user")]
        public IActionResult Put([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userViewModel);
            }

            _userAppService.Update(userViewModel);

            return Response(userViewModel);
        }

        [HttpDelete]        
        [Route("user")]
        public IActionResult Delete(Guid id)
        {
            _userAppService.Remove(id);

            return Response();
        }        
    }
}