using Eventos.IO.Infra.Data.Context;
using Eventos.IO.Domain.Events;
using Eventos.IO.Domain.Events.Repository;

namespace Eventos.IO.Infra.Data.Repository;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(EventContext context) : base(context) { }

    public Address GetAddressById(Guid addressId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Event> GetEventsByOrganizer(Guid organizerId)
    {
        throw new NotImplementedException();
    }

    public void RegisterAddress(Address address)
    {
        throw new NotImplementedException();
    }

    public void UpdateAddress(Address address)
    {
        throw new NotImplementedException();
    }
}
