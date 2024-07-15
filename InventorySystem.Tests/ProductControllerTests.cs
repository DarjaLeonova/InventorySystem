namespace InventorySystem.Tests;

using InventorySystem.BLL.Interfaces;
using InventorySystem.BLL.Models;
using InventorySystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

[TestFixture]
public class ProductsControllerTests
{
    private Mock<IProductService> _mockService;
    private ProductsController _controller;
    
    [SetUp]
    public void SetUp()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductsController(_mockService.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _controller.Dispose();
    }

    [Test]
    public async Task Index_ReturnsViewResult_WithListOfProducts()
    {
        // Arrange
        var products = new List<ProductModel> { new ProductModel() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22} };
        _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(products);

        // Act
        var result = await _controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult);

        Assert.IsInstanceOf<IEnumerable<ProductModel>>(viewResult.Model);
        var model = viewResult.Model as IEnumerable<ProductModel>;
        Assert.IsNotNull(model);
        Assert.That(model.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public async Task Add_ValidModel_RedirectsToIndex()
    {
        // Arrange
        var newItem = new ProductModel() { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22};
        _mockService.Setup(service => service.AddAsync(newItem)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Create(newItem);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectToActionResult = result as RedirectToActionResult;
        Assert.IsNotNull(redirectToActionResult);
        Assert.That(redirectToActionResult.ActionName, Is.EqualTo(nameof(ProductsController.Index)));
    }
    
    [Test]
    public async Task Add_InvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        var newItem = new ProductModel { Id = 1, Name = "Test", Description = "desc", Price = 11, Quantity = 22};
        _controller.ModelState.AddModelError("Name", "Required");

        // Act
        var result = await _controller.Create(newItem);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult);

        Assert.IsInstanceOf<ProductModel>(viewResult.Model);
        var model = viewResult.Model as ProductModel;
        Assert.IsNotNull(model);
        Assert.That(model, Is.EqualTo(newItem));
    }
}