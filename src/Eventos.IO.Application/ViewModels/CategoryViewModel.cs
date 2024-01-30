using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eventos.IO.Application.ViewModels;

public class CategoryViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }


    public SelectList Categories() => new(StateViewModel.ShowStates(), "Id", "Name");
    public List<CategoryViewModel> ShowCategories()
    {
        return new List<CategoryViewModel>()
        {
            new() { Id = new Guid("ee80f201-7c80-4d85-b1ab-51ec3f01c11a"), Name = "Meetup" },
            new() { Id = new Guid("a8829b56-33f5-4b5f-85a2-d6b5a5a13f8c"), Name = "Workshop" },
            new() { Id = new Guid("d1f16f5e-0f82-4d6b-bd8e-9e0a3cc31784"), Name = "Congress" }
        };
    }
}