using Eventos.IO.Domain.Events.Commands.Base;

namespace Eventos.IO.Domain.Events.Commands;

public class RegisterEventCommand : BaseEventCommand
{
    public RegisterEventCommand(
        string name,
        DateTime initialDate,
        DateTime endDate,
        bool isFree,
        decimal value,
        bool isOnline,
        string companyName,
        Guid organizerId,
        Address address,
        Guid categoryId)
    {
        Name = name;
        InitialDate = initialDate;
        EndDate = endDate;
        IsFree = isFree;
        Value = value;
        IsOnline = isOnline;
        CompanyName = companyName;
        OrganizerId = organizerId;
        Address = address;
        CategoryId = categoryId;
    }
}
