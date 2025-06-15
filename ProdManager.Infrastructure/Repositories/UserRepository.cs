using Microsoft.EntityFrameworkCore;
using ProdManager.Application;
using ProdManager.Domain.Entities;
using ProdManager.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserByRegistration(int registrationId) => await _context.Users.FirstOrDefaultAsync(u => u.Registration == registrationId);
    public async Task<User?> GetUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _context.Users.ToListAsync();

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var userToDelete = await _context.Users.FirstOrDefaultAsync(u => u.Registration == id);
        if (userToDelete == null) return false;
        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}