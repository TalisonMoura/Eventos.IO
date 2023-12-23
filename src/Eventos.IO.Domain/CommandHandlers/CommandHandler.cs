using FluentValidation.Results;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Core.Bus.Interfaces;
using Eventos.IO.Domain.Core.Notifications.Interfaces;

namespace Eventos.IO.Domain.CommandHandlers;

public abstract class CommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;
    private readonly IDomainNotificationHandler<DomainNotification> _notification;

    protected CommandHandler(
            IUnitOfWork unitOfWork,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notification)
    {
        _unitOfWork = unitOfWork;
        _bus = bus;
        _notification = notification;
    }

    protected void NotificationHandler(ValidationResult validationResult)
    {
        validationResult.Errors.ForEach(e =>
        {
            _bus.RaiseEvent(new DomainNotification(e.PropertyName, e.ErrorMessage));
        });
    }

    protected async Task<bool> CommitAsync()
    {
        if (_notification.HasNotification()) return false;

        var commandResponse = await _unitOfWork.CommitAsync();
        if (commandResponse.Success) return true;

        _bus.RaiseEvent(new DomainNotification("Commit", "An error ocurred when save the data"));
        return false;
    }
}