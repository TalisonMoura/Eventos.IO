using Eventos.IO.Domain.Core.Events.Interfaces;
using Eventos.IO.Domain.Events.MEvents;

namespace Eventos.IO.Domain.Events.EventHandler;

public class MEventHandler : IHandler<RegisteredMEevent>, IHandler<UpdatedMEvent>, IHandler<DeletedMEvent>
{
    public void Handle(RegisteredMEevent message)
    {
        throw new NotImplementedException();
    }

    public void Handle(UpdatedMEvent message)
    {
        throw new NotImplementedException();
    }

    public void Handle(DeletedMEvent message)
    {
        throw new NotImplementedException();
    }
}
