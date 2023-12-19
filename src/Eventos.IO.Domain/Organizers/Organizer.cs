using Eventos.IO.Domain.Core.Models;

namespace Eventos.IO.Domain.Organizers;

public class Organizer : Entity<Organizer>
{
    public Organizer(Guid id)
    {
        Id = id;
    }

    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}