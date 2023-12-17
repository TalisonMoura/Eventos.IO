using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Events.MEvents;
using Eventos.IO.Domain.Events.Commands;
using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Events.Repository;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Core.Bus.Interfaces;
using Eventos.IO.Domain.Core.Events.Interfaces;
using Eventos.IO.Domain.Core.Notifications.Interfaces;

namespace Eventos.IO.Domain.Events.CommandHandlers;

public class EventCommandHandler : CommandHandler, IHandler<RegisterEventCommand>, IHandler<UpdateEventCommand>, IHandler<DeleteEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IBus _bus;

    public EventCommandHandler(
           IEventRepository eventRepository,
           IUnitOfWork unitOfWork,
           IBus bus,
           IDomainNotificationHandler<DomainNotification> notification)
           : base(unitOfWork, bus, notification)
    {
        _eventRepository = eventRepository;
        _bus = bus;
    }

    public void Handle(RegisterEventCommand message)
    {
        var evento = new Event(
                message.Name,
                message.InitialDate,
                message.EndDate,
                message.IsFree,
                message.Value,
                message.IsOnline,
                message.CompanyName);

        if (!evento.IsValid())
        {
            NotificationHandler(evento.ValidationResult);
            return;
        }

        _eventRepository.Add(evento);

        if (Commit())
        {
            Console.WriteLine("Event successfull registered");
            _bus.RaiseEvent(new RegisteredMEevent(
                    evento.Id,
                    evento.Name,
                    evento.InitialDate,
                    evento.EndDate,
                    evento.IsFree,
                    evento.Value,
                    evento.IsOnline,
                    evento.CompanyName));
        }
    }

    public void Handle(UpdateEventCommand message)
    {
        throw new NotImplementedException();
    }

    public void Handle(DeleteEventCommand message)
    {
        throw new NotImplementedException();
    }
}