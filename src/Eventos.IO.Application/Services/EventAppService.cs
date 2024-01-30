using AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Events.Commands;
using Eventos.IO.Domain.Events.Repository;
using Eventos.IO.Domain.Core.Bus.Interfaces;

namespace Eventos.IO.Application.Services;

public class EventAppService : IEventAppService
{
    private readonly IBus _bus;
    private readonly IMapper _mapper;
    private readonly IEventRepository _repository;

    public EventAppService(
        IBus bus, 
        IMapper mapper, 
        IEventRepository repository)
    {
        _bus = bus;
        _mapper = mapper;
        _repository = repository;
    }

    public void RegisterAsync(EventViewModel entity)
    {
        var regirterCommand = _mapper.Map<RegisterEventCommand>(entity);
        _bus.SendCommand(regirterCommand);
    }

    public async Task<EventViewModel> FindByIdAsync(Guid id)
    {
        return _mapper.Map<EventViewModel>(await _repository.FindByIdAsync(id));
    }

    public async Task<IEnumerable<EventViewModel>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<EventViewModel>>(await _repository.GetAllAsync());
    }

    public IEnumerable<EventViewModel> GetOrganizerById(Guid id)
    {
        return _mapper.Map<IEnumerable<EventViewModel>>(_repository.GetEventsByOrganizer(id));
    }

    public void Update(EventViewModel entity)
    {
        // TODO: Check if the organizer is the real owner
        var updateEventCommand = _mapper.Map<UpdateEventCommand>(entity);
        _bus.SendCommand(updateEventCommand);
    }

    public void DeleteById(Guid id)
    {
        _bus.SendCommand(new  DeleteEventCommand(id));
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}
