using Eventos.IO.Domain.Core.Models;
using FluentValidation;

namespace Eventos.IO.Domain.Events;

public class Address : Entity<Address>
{
    public string Patio { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public Guid? EventId { get; private set; }

    public virtual Event Event { get; private set; }

    public Address(
        Guid id,
        string patio, 
        string number, 
        string complement, 
        string neighborhood, 
        string zipCode, 
        string city, 
        string state, 
        Guid? eventId)
    {
        Id = id;
        Patio = patio;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        ZipCode = zipCode;
        City = city;
        State = state;
        EventId = eventId;
    }

    protected Address() { }

    #region Validation
    public override bool IsValid()
    {
        RuleFor(c => c.Patio)
            .NotEmpty().WithMessage("Patio nedds to be filled")
            .Length(2, 150).WithMessage("Patio needs to be between 2 and 150 characters");

        RuleFor(c => c.Neighborhood)
            .NotEmpty().WithMessage("Neighborhood nedds to be filled")
            .Length(2, 150).WithMessage("Neighborhood needs to be between 2 and 150 characters");

        RuleFor(c => c.ZipCode)
            .NotEmpty().WithMessage("ZipCode nedds to be filled")
            .Length(8).WithMessage("ZipCode needs to be 8 characters");

        RuleFor(c => c.City)
            .NotEmpty().WithMessage("City nedds to be filled")
            .Length(2, 150).WithMessage("City needs to be between 2 and 150 characters");

        RuleFor(c => c.State)
            .NotEmpty().WithMessage("State nedds to be filled")
            .Length(2, 150).WithMessage("State needs to be between 2 and 150 characters");

        RuleFor(c => c.Number)
            .NotEmpty().WithMessage("Number nedds to be filled")
            .Length(1, 10).WithMessage("Number needs to be between 1 and 10 characters");

        ValidationResult = Validate(this);

        return ValidationResult.IsValid;
    }
    #endregion
}