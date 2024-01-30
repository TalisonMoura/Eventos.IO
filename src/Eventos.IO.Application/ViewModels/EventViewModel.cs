using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels;

public class EventViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "The min name length is {1}")]
    [MaxLength(150, ErrorMessage = "The max name length is {1}")]
    [Display(Name = "Event Name")]
    public string Name { get; set; }

    [Display(Name = "Short event description")]
    public string ShortDescription { get; set; }

    [Display(Name = "Long event description")]
    public string LongDescription { get; set; }

    [Display(Name = "Initial date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime InitialDate { get; set; }

    [Display(Name = "End date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Will be free?")]
    public bool IsFree { get; set; }

    [Display(Name = "Amount")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Amount { get; set; }

    [Display(Name = "Will be online?")]
    public bool IsOnline { get; set; }

    [Display(Name = "Company / Organizer group")]
    public string CompanyName { get; set; }

    public AddressViewModel AddressViewModel { get; set; }
    public CategoryViewModel CategoryViewModel { get; set; }

    public Guid CategoryId { get; set; }
    public Guid OrganizerId { get; set; }

    public EventViewModel()
    {
        Id = Guid.NewGuid();
        AddressViewModel = new AddressViewModel();
        CategoryViewModel = new CategoryViewModel();
    }
}
