using ListWishes.Domain.Interfaces;
using ListWishes.Domain.Core.Bus;
using ListWishes.Domain.Core.Commands;
using ListWishes.Domain.Core.Notifications;
using ListWishes.Domain.Interfaces;
using MediatR;

namespace ListWishes.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            _bus.RaiseEvent(new DomainNotification(message.MessageType, message.ValidationResult.ErrorMessage));            
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}