using InventorySystem.BLL.Interfaces;
using InventorySystem.BLL.Models;
using InventorySystem.Data.Entities;
using InventorySystem.Data.Interfaces;

namespace InventorySystem.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    
    public async Task AddAsync(ProductModel model)
    {
        var entity = ModelToEntity(model);
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(ProductModel model)
    {
        var entity = ModelToEntity(model);
        await _repository.UpdateAsync(entity);
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(EntityToModel);
    }

    public async Task<ProductModel> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return EntityToModel(product);
    }

    private ProductModel EntityToModel(Product entity)
    {
        return new ProductModel()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Quantity = entity.Quantity
        };
    }

    private Product ModelToEntity(ProductModel model)
    {
        return new Product()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Quantity = model.Quantity
        };
    }
}