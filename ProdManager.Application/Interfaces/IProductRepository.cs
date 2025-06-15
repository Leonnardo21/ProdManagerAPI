using ProdManager.Domain.Entities;

namespace ProdManager.Application;

public interface IProductRepository
{
    Task<Product?> GetById(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task Update(Product product);
    Task<bool> Delete(int id);
}
