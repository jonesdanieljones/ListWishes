using System.Threading;
using System.Threading.Tasks;
using ListWishes.Domain.Events;
using MediatR;

namespace ListWishes.Domain.EventHandlers
{
    public class WishEventHandler :
        INotificationHandler<WishRegisteredEvent>,
        INotificationHandler<WishUpdatedEvent>,
        INotificationHandler<WishRemovedEvent>
    {
        public Task Handle(WishUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(WishRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(WishRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}