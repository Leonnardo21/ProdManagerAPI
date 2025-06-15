using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProdManager.Application;
using ProdManager.Domain.Entities;
using ProdManager.Infrastructure.Data;

namespace ProdManager.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetById(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        var productId = await _context.Products.FindAsync(product.Id);

        if (productId != null)
        {
            productId.Name = product.Name;
            productId.Description = product.Description;
            productId.Price = product.Price;
            productId.StockQuantity = product.StockQuantity;
            productId.Manufacture = product.Manufacture;
            productId.Expiration = product.Expiration;
            productId.IsActive = product.IsActive;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> Delete(int id)
    {
        var productId = await _context.Products.FindAsync(id);
        if (productId == null)
        {
            return false;
        }
        _context.Products.Remove(productId);
        await _context.SaveChangesAsync();
        return true;
    }
}