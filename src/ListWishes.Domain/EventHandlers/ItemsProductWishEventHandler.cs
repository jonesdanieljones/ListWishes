using System.Threading;
using System.Threading.Tasks;
using Eventos.IO.Domain.Eventos.Events;
using ListWishes.Domain.Events;
using MediatR;

namespace ListWishes.Domain.EventHandlers
{
    public class ItemsProductWishEventHandler :
        INotificationHandler<ItemsProductWishRegisteredEvent>,
        INotificationHandler<ItemsProductWishUpdateEvent>,
        INotificationHandler<ItemsProductWishRemovedEvent>
    {
        public Task Handle(ItemsProductWishUpdateEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ItemsProductWishRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ItemsProductWishRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}