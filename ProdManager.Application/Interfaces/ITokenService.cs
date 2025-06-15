using ProdManager.Domain.Entities;

namespace ProdManager.Application;

public interface ITokenService
{
    string GenerateToken(User user);
}