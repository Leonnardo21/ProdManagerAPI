using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ProdManager;

public class Configuration
{
    public static string SecretKey => "458ddfc0-1f64-4bb4-bf09-a4eeefafd952";

    public static TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true
        };
    }
}