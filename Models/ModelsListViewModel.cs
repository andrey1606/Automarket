using Microsoft.AspNetCore.Mvc.Rendering;
namespace Automarket.Models;

public class ModelsListViewModel
{
    public IEnumerable<Model> Models { get; set; } = new List<Model>();
    public SelectList Brands { get; set; } = new SelectList(new List<Brand>(), "Id", "Name");
}

