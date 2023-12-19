using Eventos.IO.Domain.Core.Events.Interfaces;

namespace Eventos.IO.Domain.Events.MEvents;

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