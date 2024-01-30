using Eventos.IO.Domain.Core.Commands;

namespace Eventos.IO.Domain.Events.Commands.Base;

public abstract class BaseEventCommand : Command
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
    public Guid OrganizerId { get; protected set; }
    public Guid CategoryId { get; protected set; }
}