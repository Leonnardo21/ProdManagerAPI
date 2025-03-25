using Microsoft.EntityFrameworkCore;
using ProdManager.Data;
using ProdManager.Entities;
using ProdManager.Repositories.Interface;

namespace ProdManager.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ProdManagerDbContext _context;

    public UserRepository(ProdManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddUserAsync(User model)
    {
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User model)
    {
        _context.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}