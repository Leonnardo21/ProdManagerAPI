using ProdManager.Entities;

namespace ProdManager.Repositories.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task AddUserAsync(User model);
    Task UpdateUserAsync(User model);
    Task DeleteUserAsync(int id);
}