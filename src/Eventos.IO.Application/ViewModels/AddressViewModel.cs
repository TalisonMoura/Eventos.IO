using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels;

public class AddressViewModel
{
    [Key]
    public Guid Id { get; set; }
    public string Patio { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public AddressViewModel() 
    { 
        Id = Guid.NewGuid();
    }

    public SelectList States() => new(StateViewModel.ShowStates(), "UF", "Name");
    public override string ToString() => $"{Patio}, {Number} - {Complement}, {Neighborhood} - {ZipCode}, {City}";
}
