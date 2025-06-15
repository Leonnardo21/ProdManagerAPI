using ProdManager.Domain.Entities;

namespace ProdManager.Application;

public interface ICategoryRepository
{
    Task<Category?> GetById(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task Update(Category category);
    Task<bool> Delete(int id);
}