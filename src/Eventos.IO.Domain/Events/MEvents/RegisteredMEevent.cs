using Eventos.IO.Domain.Events.MEvents.Base;

namespace Eventos.IO.Domain.Events.MEvents;

public class RegisteredMEevent : BaseMEvent
{
    public RegisteredMEevent(
        Guid id,
        string name,
        DateTime initialDate,
        DateTime endDate,
        bool isFree,
        decimal value,
        bool isOnline,
        string companyName)
    {
        Id = id;
        Name = name;
        InitialDate = initialDate;
        EndDate = endDate;
        IsFree = isFree;
        Value = value;
        IsOnline = isOnline;
        CompanyName = companyName;
        AggregateId = id;
    }
}