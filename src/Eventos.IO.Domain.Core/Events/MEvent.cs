namespace Eventos.IO.Domain.Core.Events;

public abstract class MEvent : Message
{
    public DateTime TimeStamp { get; private set; }

    protected MEvent()
    {
        TimeStamp = DateTime.Now;
    }
}
