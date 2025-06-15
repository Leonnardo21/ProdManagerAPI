using ProdManager.Domain.Entities;

namespace ProdManager.Application;

public interface IUserRepository
{
    Task<User?> GetUserByRegistration(int registrationId);
    Task<User?> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    Task Update(User user);
    Task<bool> Delete(int id);
}