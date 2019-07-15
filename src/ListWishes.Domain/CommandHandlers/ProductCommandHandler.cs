using System;
using System.Threading;
using System.Threading.Tasks;
using ListWishes.Domain.Commands;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Core.Notifications;
using ListWishes.Domain.Events;
using ListWishes.Domain.Interfaces;
using ListWishes.Domain.Models;
using MediatR;

namespace ListWishes.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>,
        IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductCommandHandler(IProductRepository productRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var product = new Product(Guid.NewGuid(), message.Name);

            _productRepository.Add(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRegisteredEvent(product.Id, product.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var product = new Product(message.Id, message.Name);

            _productRepository.Update(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductUpdatedEvent(product.Id, product.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _productRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}