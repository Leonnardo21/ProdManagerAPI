namespace ProdManager.Application.DTOs.Auth;

public class LoginRequest
{
    public int Registration { get; set; }
    public string Password { get; set; } = string.Empty;
}