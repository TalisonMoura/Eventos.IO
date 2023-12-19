using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Commands;

namespace Eventos.IO.Domain.Core.Bus.Interfaces;

public interface IBus
{
    void SendCommand<T>(T theCommand) where T : Command;
    void RaiseEvent<T>(T theEvent) where T : MEvent;
}
