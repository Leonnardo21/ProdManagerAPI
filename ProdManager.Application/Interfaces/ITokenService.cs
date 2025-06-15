using ProdManager.Domain.Entities;

namespace ProdManager.Application;

public interface IAuthService
{
    string GenerateToken(User user);
}