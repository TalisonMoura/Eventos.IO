using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Events.Commands;

namespace Eventos.IO.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<EventViewModel, RegisterEventCommand>()
            .ConstructUsing(x => new RegisterEventCommand(x.Name, x.ShortDescription, x.LongDescription, x.InitialDate, x.EndDate, x.IsFree, x.Amount, x.IsOnline, x.CompanyName, x.OrganizerId, x.CategoryId,
                new IncludeAddressEventCommand(x.AddressViewModel.Id, x.AddressViewModel.Patio, x.AddressViewModel.Number, x.AddressViewModel.Complement, x.AddressViewModel.Neighborhood, x.AddressViewModel.ZipCode, x.AddressViewModel.City, x.AddressViewModel.State, x.Id)));
    
        CreateMap<EventViewModel, UpdateEventCommand>()
            .ConstructUsing(x => new UpdateEventCommand(x.Id, x.Name, x.ShortDescription, x.LongDescription, x.InitialDate, x.EndDate, x.IsFree, x.Amount, x.IsOnline, x.CompanyName, x.OrganizerId, x.CategoryId));

        CreateMap<EventViewModel, DeleteEventCommand>()
            .ConstructUsing(x => new DeleteEventCommand(x.Id));
    }
}