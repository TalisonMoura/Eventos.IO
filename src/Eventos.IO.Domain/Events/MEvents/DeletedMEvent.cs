using Eventos.IO.Domain.Events.MEvents.Base;

namespace Eventos.IO.Domain.Events.MEvents;

public class DeletedMEvent : BaseMEvent
{
    public DeletedMEvent(Guid id)
    {
        Id = id;
        AggregateId = Id;
    }
}
