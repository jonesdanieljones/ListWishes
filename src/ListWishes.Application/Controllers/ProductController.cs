using AutoMapper;
using ListWishes.Application.Interfaces;
using ListWishes.Application.ViewModels;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ListWishes.Application.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(
            IProductAppService productAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _productAppService = productAppService;
        }

        [HttpGet]        
        [Route("customer-management")]
        public IActionResult Get()
        {
            return Response(_productAppService.GetAll());
        }

        [HttpGet]        
        [Route("customer-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var productViewModel = _productAppService.GetById(id);

            return Response(productViewModel);
        }

        [HttpPost]        
        [Route("customer-management")]
        public IActionResult Post([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _productAppService.Register(productViewModel);

            return Response(productViewModel);
        }

        [HttpPut]        
        [Route("customer-management")]
        public IActionResult Put([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _productAppService.Update(productViewModel);

            return Response(productViewModel);
        }

        [HttpDelete]        
        [Route("customer-management")]
        public IActionResult Delete(Guid id)
        {
            _productAppService.Remove(id);

            return Response();
        }        
    }
}