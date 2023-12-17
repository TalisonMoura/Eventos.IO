namespace Eventos.IO.Domain.Core.Events.Interfaces;

public interface IHandler<in TEntity> where TEntity : Message
{
    void Handle(TEntity message);
}