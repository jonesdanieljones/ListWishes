﻿using System.Threading;
using System.Threading.Tasks;
using ListWishes.Domain.Events;
using MediatR;

namespace ListWishes.Domain.EventHandlers
{
    public class UserEventHandler :
        INotificationHandler<UserRegisteredEvent>,
        INotificationHandler<UserUpdatedEvent>,
        INotificationHandler<UserRemovedEvent>
    {
        public Task Handle(UserUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(UserRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(UserRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}