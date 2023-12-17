using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Events.Interfaces;

namespace Eventos.IO.Domain.Core.Notifications.Interfaces;

public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
{
    bool HasNotification();
    List<T> GetNotifications();
}