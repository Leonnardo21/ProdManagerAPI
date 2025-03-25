using Microsoft.AspNetCore.Mvc;
using ProdManager.Entities;

namespace ProdManager.Repositories.Interface;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task PostAsync(Product model);
    Task PutAsync(Product model);
    Task DeleteAsync(int id);
}