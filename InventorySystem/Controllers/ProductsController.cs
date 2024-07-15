using InventorySystem.BLL.Interfaces;
using InventorySystem.BLL.Models;
using InventorySystem.Data.Data;
using InventorySystem.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Controllers;
public class ProductsController : Controller
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET: Products
    public async Task<IActionResult> Index()
    {
        return View(await _service.GetAllAsync());
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
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _service.GetByIdAsync(id);
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

            await _service.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
}