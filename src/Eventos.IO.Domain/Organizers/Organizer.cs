using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Events;

namespace Eventos.IO.Domain.Organizers;

public class Organizer : Entity<Organizer>
{
    public Organizer(Guid id, string name, string cPF, string email)
    {
        Id = id;
        Name = name;
        CPF = cPF;
        Email = email;
    }

    protected Organizer() { }

    public string Name { get; private set; }
    public string CPF { get; private set; }
    public string Email { get; private set; }

    public virtual ICollection<Event> Events { get; private set; }

    public override bool IsValid()
    {
        return true;
    }
}