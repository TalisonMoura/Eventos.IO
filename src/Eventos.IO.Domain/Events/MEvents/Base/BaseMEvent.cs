using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Events.MEvents.Base;

public abstract class BaseMEvent : MEvent
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string ShortDescription { get; protected set; }
    public string LongDescription { get; protected set; }
    public DateTime InitialDate { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public bool IsFree { get; protected set; }
    public decimal Value { get; protected set; }
    public bool IsOnline { get; protected set; }
    public string CompanyName { get; protected set; }
}
