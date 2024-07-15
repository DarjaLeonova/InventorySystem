namespace InventorySystem.BLL.Interfaces;

public interface ICrud<TModel>
    where TModel : class
{
    Task AddAsync(TModel model);

    Task UpdateAsync(TModel model);

    Task<IEnumerable<TModel>> GetAllAsync();
    
    Task<TModel> GetByIdAsync(int id);
}