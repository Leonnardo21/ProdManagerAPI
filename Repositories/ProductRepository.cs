using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdManager.Data;
using ProdManager.Entities;
using ProdManager.Repositories.Interface;

namespace ProdManager.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProdManagerDbContext _context;

    public ProductRepository(ProdManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
            return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task PostAsync(Product model)
    {
        await _context.Products.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task PutAsync(Product model)
    {
        _context.Products.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}