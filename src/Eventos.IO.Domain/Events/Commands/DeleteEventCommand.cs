using Eventos.IO.Domain.Events.Commands.Base;

namespace Eventos.IO.Domain.Events.Commands;

public class DeleteEventCommand : BaseEventCommand
{
    public DeleteEventCommand(Guid id) 
    {
        Id = id;
        AggregateId = Id;
    }
}
