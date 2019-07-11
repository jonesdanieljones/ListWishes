using ListWishes.Domain.Core.Commands;
using ListWishes.Domain.Core.Events;
using System.Threading.Tasks;

namespace ListWishes.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
