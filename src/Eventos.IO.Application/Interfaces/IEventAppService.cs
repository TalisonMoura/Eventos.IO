using Eventos.IO.Application.ViewModels;

namespace Eventos.IO.Application.Interfaces;

public interface IEventAppService : IDisposable
{
    void RegisterAsync(EventViewModel entity);
    Task<EventViewModel> FindByIdAsync(Guid id);
    Task<IEnumerable<EventViewModel>> GetAllAsync();
    IEnumerable<EventViewModel> GetOrganizerById(Guid id);
    void Update(EventViewModel entity);
    void DeleteById(Guid id);
}