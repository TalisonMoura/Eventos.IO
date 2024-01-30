using Eventos.IO.Domain.Events.Commands.Base;

namespace Eventos.IO.Domain.Events.Commands;

public class RegisterEventCommand : BaseEventCommand
{
    public RegisterEventCommand(
        string name,
        string shortDescription,
        string longDescription,
        DateTime initialDate,
        DateTime endDate,
        bool isFree,
        decimal value,
        bool isOnline,
        string companyName,
        Guid organizerId,
        Guid categoryId,
        IncludeAddressEventCommand address)
    {
        Name = name;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        InitialDate = initialDate;
        EndDate = endDate;
        IsFree = isFree;
        Value = value;
        IsOnline = isOnline;
        CompanyName = companyName;
        OrganizerId = organizerId;
        CategoryId = categoryId;
        Address = address;
    }
    public IncludeAddressEventCommand Address { get; private set; }
}
