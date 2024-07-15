using InventorySystem.Data.Entities;

namespace InventorySystem.Data.Interfaces;

public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity);

    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task<TEntity> GetByIdAsync(int id);

    Task UpdateAsync(TEntity entity);
}