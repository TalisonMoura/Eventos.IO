using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Events.MEvents;
using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Events.Repository;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Core.Bus.Interfaces;
using Eventos.IO.Domain.Core.Events.Interfaces;
using Eventos.IO.Domain.Core.Notifications.Interfaces;

namespace Eventos.IO.Domain.Events.Commands;

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
        var evento = Event.EventFactory.NewFullEvent(
                message.Id,
                message.Name,
                message.ShortDescription,
                message.LongDescription,
                message.InitialDate,
                message.EndDate,
                message.IsFree,
                message.Value,
                message.IsOnline,
                message.CompanyName,
                message.OrganizerId,
                message.Address,
                message.CategoryId);

        if (!IsValidEvent(evento)) return;

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
        var currentEvent = _eventRepository.GetById(message.Id);

        if (!IsEventExist(message.Id, message.MessageType)) return; 

        var evento = Event.EventFactory.NewFullEvent(
                message.Id,
                message.Name,
                message.ShortDescription,
                message.LongDescription,
                message.InitialDate,
                message.EndDate,
                message.IsFree,
                message.Value,
                message.IsOnline,
                message.CompanyName,
                message.OrganizerId,
                currentEvent.Address,
                message.CategoryId);

        if (!IsValidEvent(evento)) return;

        _eventRepository.Update(evento);

        if (Commit())
        {
            _bus.RaiseEvent(new UpdatedMEvent(
                    evento.Id,
                    evento.Name,
                    evento.ShortDescription,
                    evento.LongDescription,
                    evento.InitialDate,
                    evento.EndDate,
                    evento.IsFree,
                    evento.Value,
                    evento.IsOnline,
                    evento.CompanyName
                ));
        }
    }

    public void Handle(DeleteEventCommand message)
    {
        if (!IsEventExist(message.Id, message.MessageType)) return;

        _eventRepository.Delete(message.Id);

        if (Commit())
        {
            _bus.RaiseEvent(new DeletedMEvent(message.Id));
        }
    }

    private bool IsValidEvent(Event evento)
    {
        if (evento.IsValid()) return true;

        NotificationHandler(evento.ValidationResult);
        return false;
    }
    private bool IsEventExist(Guid id, string messageType)
    {
        var evento = _eventRepository.GetById(id);

        if(evento != null) return true;

        _bus.RaiseEvent(new DomainNotification(messageType, "Event not found."));
        return false;
    }
}