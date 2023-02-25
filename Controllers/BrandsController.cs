using Microsoft.AspNetCore.Mvc;
using Automarket.Models;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Controllers;

public class BrandsController : Controller
{
    private readonly AutomarketDbContext _context;

    public BrandsController(AutomarketDbContext context)
    {
        _context = context;
    }

    // GET: Brands
    public async Task<IActionResult> Index()
    {
        var brands = await _context.Brands.ToListAsync();
        return View(brands);
    }

    public IActionResult Create()
    {
        return View();
    }

    // POST: Brands/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Active")] Brand brand)
    {
        if (ModelState.IsValid)
        {
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(brand);
    }

    // GET: Brands/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    // POST: Brands/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Active")] Brand brand)
    {
        if (id != brand.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(brand);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(brand.Id))
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
        return View(brand);
    }

    // DELETE: Brands/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }
        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BrandExists(int id)
    {
        return _context.Brands.Any(e => e.Id == id);
    }
}
