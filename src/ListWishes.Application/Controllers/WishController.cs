using ListWishes.Application.Interfaces;
using ListWishes.Application.ViewModels;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Core.Notifications;
using ListWishes.Service.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListWishes.Application.Controllers
{
    public class WishController : ApiController
    {
        private readonly IWishAppService _wishAppService;

        public WishController(
            IWishAppService wishAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _wishAppService = wishAppService;
        }

        [HttpGet]
        [Route("wish")]
        public IActionResult Get()
        {
            return Response(_wishAppService.GetAll());
        }

        [HttpGet]
        [Route("wish/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var productViewModel = _wishAppService.GetById(id);

            return Response(productViewModel);
        }

        [HttpPost]
        [Route("wish")]
        public IActionResult Post([FromBody]WishViewModel wishViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(wishViewModel);
            }

            _wishAppService.Register(wishViewModel);

            return Response(wishViewModel);
        }

        [HttpPut]
        [Route("wish")]
        public IActionResult Put([FromBody]WishViewModel wishViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(wishViewModel);
            }

            _wishAppService.Update(wishViewModel);

            return Response(wishViewModel);
        }

        [HttpDelete]
        [Route("wish")]
        public IActionResult Delete(Guid id)
        {
            _wishAppService.Remove(id);

            return Response();
        }
    }
}