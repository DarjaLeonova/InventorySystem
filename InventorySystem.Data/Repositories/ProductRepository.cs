using InventorySystem.Data.Data;
using InventorySystem.Data.Entities;
using InventorySystem.Data.Interfaces;

namespace InventorySystem.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await Task.FromResult<IEnumerable<Product>>(_context.Products);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task UpdateAsync(Product entity)
    {
        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
    }
}