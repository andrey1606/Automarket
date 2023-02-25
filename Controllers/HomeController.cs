using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Automarket.Models;

namespace Automarket.Controllers;

public class HomeController : Controller
{
    AutomarketDbContext _context;
    public HomeController(AutomarketDbContext context)
    {
        _context = context;
        if (!_context.Brands.Any())
        {
            context.Brands.AddRange(new List<Brand>
            {
                new Brand { Name = "BMW", Active = true },
                new Brand { Name = "Toyota", Active = true },
                new Brand { Name = "Ford", Active = false },
                new Brand { Name = "Honda", Active = true },
                new Brand { Name = "Chevrolet", Active = false },
                new Brand { Name = "Mercedes-Benz", Active = true },
                new Brand { Name = "Audi", Active = true },
                new Brand { Name = "Nissan", Active = false }
            });
            context.SaveChanges();
        }
        if (!context.Models.Any())
        {
            var bmwBrand = context.Brands.First(b => b.Name == "BMW");
            var toyotaBrand = context.Brands.First(b => b.Name == "Toyota");
            var hondaBrand = context.Brands.First(b => b.Name == "Honda");
            var mercedesBrand = context.Brands.First(b => b.Name == "Mercedes-Benz");

            context.Models.AddRange(new List<Model>
            {
                new Model { Name = "X5", Active = true, Brand = bmwBrand },
                new Model { Name = "3 Series", Active = true, Brand = bmwBrand },
                new Model { Name = "Corolla", Active = true, Brand = toyotaBrand },
                new Model { Name = "Camry", Active = false, Brand = toyotaBrand },
                new Model { Name = "Accord", Active = true, Brand = hondaBrand },
                new Model { Name = "C-Class", Active = true, Brand = mercedesBrand },
                new Model { Name = "E-Class", Active = false, Brand = mercedesBrand },
                new Model { Name = "A4", Active = true, Brand = context.Brands.First(b => b.Name == "Audi") },
            });

            context.SaveChanges();
        }
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
