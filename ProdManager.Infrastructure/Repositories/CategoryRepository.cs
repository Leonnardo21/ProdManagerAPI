using Microsoft.EntityFrameworkCore;
using ProdManager.Application;
using ProdManager.Domain.Entities;
using ProdManager.Infrastructure.Data;

namespace ProdManager.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Category?> GetById(int id) => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

    public async Task AddAsync(Category category)
    {
       await _context.Categories.AddAsync(category);
       await _context.SaveChangesAsync();
    }

    public async Task Update(Category category)
    {
        var categoryId = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
        if (categoryId != null)
        {
            categoryId.Name = category.Name;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> Delete(int id)
    {
        var categoryToDelete = await _context.Categories.FindAsync(id);
        if (categoryToDelete == null) return false;
        _context.Categories.Remove(categoryToDelete);
        await _context.SaveChangesAsync();
        
        return true;
    }
}