using System;
using System.Threading;
using System.Threading.Tasks;
using Eventos.IO.Domain.Eventos.Events;
using ListWishes.Domain.Commands;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Core.Notifications;
using ListWishes.Domain.Events;
using ListWishes.Domain.Interfaces;
using ListWishes.Domain.Models;
using MediatR;

namespace ListWishes.Domain.CommandHandlers
{
    public class ItemsProductWishCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewItemsProductWishCommand, bool>,
        IRequestHandler<UpdateItemsProductWishCommand, bool>,
        IRequestHandler<RemoveItemsProductWishCommand, bool>
    {
        private readonly IItemsProductWishRepository _itemsProductWishRepository;
        private readonly IMediatorHandler Bus;

        public ItemsProductWishCommandHandler(IItemsProductWishRepository itemsProductWishRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _itemsProductWishRepository = itemsProductWishRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewItemsProductWishCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var itemsProductWish = new ItemsProductWish(Guid.NewGuid(), message.ProductId, message.WishId);

            _itemsProductWishRepository.Add(itemsProductWish);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemsProductWishRegisteredEvent(itemsProductWish.Id, itemsProductWish.WishId, itemsProductWish.ProductId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateItemsProductWishCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var itemsProductWish = new ItemsProductWish(message.Id, message.WishId, message.ProductId);
            _itemsProductWishRepository.Update(itemsProductWish);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemsProductWishUpdateEvent(itemsProductWish.Id));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveItemsProductWishCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _itemsProductWishRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemsProductWishRemovedEvent(message.Id, message.ProductId));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _itemsProductWishRepository.Dispose();
        }
    }
}