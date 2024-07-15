using InventorySystem.BLL.Interfaces;
using InventorySystem.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers;
public class ProductsController(IProductService service) : Controller
{
    // GET: Products
    public async Task<IActionResult> Index()
    {
        return View(await service.GetAllAsync());
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    public async Task<IActionResult> Create(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            await service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var product = await service.GetByIdAsync(id);
        return View(product);
    }

    // POST: Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity")] ProductModel product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await service.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }
}