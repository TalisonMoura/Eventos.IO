using FluentValidation;
using Eventos.IO.Domain.Organizers;
using Eventos.IO.Domain.Core.Models;

namespace Eventos.IO.Domain.Events;

public class Event : Entity<Event>
{
    public Event(
        string name,
        DateTime initialDate,
        DateTime endDate,
        bool isFree,
        decimal value,
        bool isOnline,
        string companyName)
    {
        Id = Guid.NewGuid();
        Name = name;
        InitialDate = initialDate;
        EndDate = endDate;
        IsFree = isFree;
        Value = value;
        IsOnline = isOnline;
        CompanyName = companyName;
    }

    public string Name { get; private set; }
    public string ShortDescription { get; private set; }
    public string LongDescription { get; private set; }
    public DateTime InitialDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsFree { get; private set; }
    public decimal Value { get; private set; }
    public bool IsOnline { get; private set; }
    public string CompanyName { get; private set; }
    public Category Category { get; private set; }
    public Address Address { get; private set; }
    public Organizer Organizer { get; private set; }
    public ICollection<Tags> Tags { get; private set; }

    public override bool IsValid()
    {
        Validate();
        return ValidationResult.IsValid;
    }

    private void Validate()
    {
        ValidateName();
        ValidateValue();
        ValidateData();
        ValidateLocal();
        ValidateCompanyName();
        ValidationResult = Validate(this);
    }

    private void ValidateName()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("The name cannot be null")
            .Length(2, 150).WithMessage("The name must have be between 2 and 150 characters");
    }

    private void ValidateValue()
    {
        if (!IsFree)
            RuleFor(e => e.Value)
                .ExclusiveBetween(1, 50000)
                .WithMessage("The value must be between 1.00 and 50.000");

        if (IsFree)
            RuleFor(e => e.Value)
                .ExclusiveBetween(0, 0).When(e => e.IsFree)
                .WithMessage("The value cannot be less than 0 for a free event");
    }

    private void ValidateData()
    {
        RuleFor(d => d.InitialDate)
            .GreaterThan(d => d.EndDate)
            .WithMessage("The initial date must have be greater than event end date");

        RuleFor(d => d.InitialDate)
            .LessThan(DateTime.Now)
            .WithMessage("The initial date cannot be less than the current date");
    }

    private void ValidateLocal()
    {
        if (IsOnline)
            RuleFor(o => o.IsOnline)
                .NotNull().When(o => o.IsOnline)
                .WithMessage("The event cannot have an address if it's online");

        if (!IsOnline)
            RuleFor(o => o.IsOnline)
                .NotNull().When(o => o.IsOnline == false)
                .WithMessage("The event must have be an address");
    }

    private void ValidateCompanyName()
    {
        RuleFor(c => c.CompanyName)
            .NotEmpty().WithMessage("The organizer name needs to be given")
            .Length(2, 150).WithMessage("The organizer name needs to be between 2 and 150 characters");
    }
}