using InventorySystem.BLL.Interfaces;
using InventorySystem.BLL.Models;
using InventorySystem.BLL.Services;
using InventorySystem.Data.Entities;
using InventorySystem.Data.Interfaces;
using Moq;

namespace InventorySystem.Tests;

[TestFixture]
public class ProductServiceTests
{
    private Mock<IProductRepository> _repositoryMock;
    private IProductService _service;
    
    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IProductRepository>();
        _service = new ProductService(_repositoryMock.Object);
    }
    
    [Test]
    public async Task GetAllAsync_ShouldReturnAllProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22},
            new() { Id = 1, Name = "Tes1t", Description = "desc1", Price = 11, Quantity = 22}
        };

        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.First().Name, Is.EqualTo("Test"));
        Assert.That(result.Last().Name, Is.EqualTo("Tes1t"));
    }
    
    [Test]
    public async Task AddAsync_ShouldAddProduct()
    {
        // Arrange
        var product = new ProductModel() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22};

        // Act
        await _service.AddAsync(product);

        // Assert
        _repositoryMock.Verify(repo => repo.AddAsync(It.Is<Product>(t => t.Name == "Test")), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_ShouldUpdateProduct()
    {
        // Arrange
        var product = new ProductModel() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22};

        // Act
        await _service.UpdateAsync(product);

        // Assert
        _repositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Product>(t => t.Id == 1 && t.Name == "Test")), Times.Once);
    }
}