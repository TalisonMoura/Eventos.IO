using Eventos.IO.Domain.Events.Commands.Base;

namespace Eventos.IO.Domain.Events.Commands;

public class UpdateEventCommand : BaseEventCommand
{
    public UpdateEventCommand(
        Guid id,
        string name,
        string shortDescription,
        string longDescription,
        DateTime initialDate,
        DateTime endDate,
        bool isFree,
        decimal value,
        bool isOnline,
        string companyName)
    {
        Id = id;
        Name = name;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        InitialDate = initialDate;
        EndDate = endDate;
        IsFree = isFree;
        Value = value;
        IsOnline = isOnline;
        CompanyName = companyName;
    }
}