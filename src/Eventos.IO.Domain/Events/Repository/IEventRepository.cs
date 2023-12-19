using Eventos.IO.Domain.Interfaces;

namespace Eventos.IO.Domain.Events.Repository;

public interface IEventRepository : IRepository<Event>
{
    IEnumerable<Event> GetEventsByOrganizer(Guid organizerId);
    Address GetAddressById(Guid addressId);
    void RegisterAddress(Address address);
    void UpdateAddress(Address address);
}
