using Microsoft.AspNetCore.Mvc;
using Automarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Automarket.Controllers;

public class ModelsController : Controller
{
    private readonly AutomarketDbContext _context;

    public ModelsController(AutomarketDbContext context)
    {
        _context = context;
    }

    // GET: Models
    public async Task<IActionResult> Index(int? brand)
    {
        IQueryable<Model> models = _context.Models
                .Include(m => m.Brand);

        if (brand.HasValue && brand != 0)
        {
            models = models.Where(m => m.BrandId == brand);
        }
        List<Brand> brands = _context.Brands.ToList();
        brands.Insert(0, new Brand { Name = "All", Id = 0 });
        var viewModel = new ModelsListViewModel
        {
            Models = models.ToList(),
            Brands = new SelectList(brands, "Id", "Name", brand)
        };

        return View(viewModel);
    }
    // GET: Models/Create
    public IActionResult Create()
    {
        ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BrandId,Name,Active")] Model model)
    {
        if (ModelState.IsValid)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", model.BrandId);
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine(error.ErrorMessage);
        }
        return View(model);
    }



    // GET: Models/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var model = await _context.Models.FindAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        ViewData["BrandId"] = new SelectList(_context.Brands.Include(b => b.Models), "Id", "Name", model.BrandId);
        return View(model);
    }

    // POST: Models/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,Name,Active")] Model model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", model.BrandId);
        return View(model);
    }

    // DELETE: Models/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var model = await _context.Models.FindAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        _context.Models.Remove(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    private bool ModelExists(int id)
    {
        return _context.Models.Any(e => e.Id == id);
    }
}
