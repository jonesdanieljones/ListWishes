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
    public class WishCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewWishCommand, bool>,
        IRequestHandler<UpdateWishCommand, bool>,
        IRequestHandler<RemoveWishCommand, bool>
    {
        private readonly IWishRepository _wishRepository;
        private readonly IMediatorHandler Bus;

        public WishCommandHandler(IWishRepository wishRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _wishRepository = wishRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewWishCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var wish = new Wish(Guid.NewGuid(), message.UserId);

            _wishRepository.Add(wish);

            if (Commit())
            {
                Bus.RaiseEvent(new WishRegisteredEvent(wish.Id,wish.UserId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateWishCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var wish = new Wish(message.Id, message.UserId);
            _wishRepository.Update(wish);

            if (Commit())
            {
                Bus.RaiseEvent(new WishUpdatedEvent(wish.Id, wish.UserId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveWishCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _wishRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new WishRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _wishRepository.Dispose();
        }
    }
}