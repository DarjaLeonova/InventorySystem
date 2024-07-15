using InventorySystem.Data.Data;
using InventorySystem.Data.Entities;
using InventorySystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Tests;

[TestFixture]
public class ProductRepositoryTests
{
     private ApplicationDbContext _context;
    private ProductRepository _repository;
    
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDb")
            .Options;

        _context = new ApplicationDbContext(options);
        _repository = new ProductRepository(_context);
    }
    
    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
    
    [Test]
    public async Task AddAsync_ShouldAddItem()
    {
        // Arrange
        var todoItem = new Product() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22};

        // Act
        await _repository.AddAsync(todoItem);
        var result = await _context.Products.FirstOrDefaultAsync(t => t.Name == "Test");
        
        // Assert
        Assert.That(result.Name, Is.EqualTo("Test"));
    }
    
    [Test]
    public async Task GetAllAsync_ShouldReturnAllItems()
    {
        // Arrange
        _context.Products.Add(new Product() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22});
        _context.Products.Add(new Product() { Id = 2, Name = "Test1", Description = "desc1", Price = 11, Quantity = 22});
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(2));
    }
    
    [Test]
    public async Task UpdateAsync_ShouldUpdateItem()
    {
        // Arrange
        var todoItem = new Product() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22};
        _context.Products.Add(todoItem);
        await _context.SaveChangesAsync();
    
        // Act
        todoItem.Name = "test1";
        await _repository.UpdateAsync(todoItem);
        var result = await _context.Products.FirstOrDefaultAsync(t => t.Id == todoItem.Id);
    
        // Assert
        Assert.That(result.Name, Is.EqualTo("test1"));
    }
}