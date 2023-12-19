using Eventos.IO.Domain.Core.Models;

namespace Eventos.IO.Domain.Events;

public class Category : Entity<Category>
{
    public Category(Guid id)
    {
        Id = id;
    }
    
    public string Name { get; private set; }
    public virtual ICollection<Event> Events { get; set; }

    protected Category() { }

    public override bool IsValid()
    {
        return true;
    }
}