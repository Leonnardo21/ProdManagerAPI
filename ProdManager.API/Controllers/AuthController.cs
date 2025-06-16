using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProdManager.Application;
using ProdManager.Application.DTOs.Auth;
using ProdManager.Domain.Entities;

namespace ProdManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(IUserRepository userRepository, ITokenService tokenService,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (await _userRepository.GetUserByRegistration(request.Registration) != null)
            return BadRequest("Usuário já cadastrado");

        var user = new User
        {
            Registration = request.Registration,
            Name = request.Name,
            Email = request.Email,
        };
        
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        await _userRepository.AddUserAsync(user);

        var token = _tokenService.GenerateToken(user);
        
        return Ok(new
        {
            message = "Usuário registrado com sucesso",
            token,
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest user)
    {
        var userLogin = await _userRepository.GetUserByRegistration(user.Registration);
        if (userLogin == null) return Unauthorized("Matricula ou Senha inválidos.");

        var result = _passwordHasher.VerifyHashedPassword(userLogin, userLogin.PasswordHash, user.Password);
        if (result == PasswordVerificationResult.Failed) return Unauthorized("Matricula ou Senha inválidos.");

        var token = _tokenService.GenerateToken(userLogin);

        return Ok(new { Token = token });
    }
}