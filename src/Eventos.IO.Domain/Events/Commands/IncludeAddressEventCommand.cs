using Eventos.IO.Domain.Core.Commands;

namespace Eventos.IO.Domain.Events.Commands;

public class IncludeAddressEventCommand : Command
{
    public IncludeAddressEventCommand(
        Guid id,
        string patio,
        string number,
        string complement,
        string neighborhood,
        string zipCode,
        string city,
        string state,
        Guid? eventId)
    {
        Id = id;
        Patio = patio;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        ZipCode = zipCode;
        City = city;
        State = state;
        EventId = eventId;
    }

    public Guid Id { get; set; }
    public string Patio { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public Guid? EventId { get; private set; }
}
