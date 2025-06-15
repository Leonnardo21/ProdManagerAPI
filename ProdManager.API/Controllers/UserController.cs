using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProdManager.Application;
using ProdManager.Domain.Entities;

namespace ProdManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserController(IUserRepository userRepository, IPasswordHasher<User>  passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userRepository.GetAllUsersAsync();
        return Ok(user);
    }
    
    //Método Get Por ID
    [HttpGet("by-registration/{registrationId:int}")]
    public async Task<IActionResult> GetUserById([FromRoute] int registrationId)
    {
        var user = await _userRepository.GetUserByRegistration(registrationId);
        if (user == null) return NotFound("Usuário não encontrado.");
        return Ok(user);
    }

    [HttpGet("by-email")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("O email é obrigatório");
        }
        
        var user = await _userRepository.GetUserByEmailAsync(email);
        if(user == null) return NotFound("Usuário não encontrado.");
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        var userModel = new User
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Email = user.Email,
            Registration = user.Registration
        };

        userModel.PasswordHash = _passwordHasher.HashPassword(user, userModel.PasswordHash);
        
        await _userRepository.AddUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { registrationId = user.Registration }, user);
    }

    [HttpPut("{registrationId:int}")]
    public async Task<IActionResult> Put([FromRoute] int registrationId,[FromBody] User user)
    {
        var userToUpdate = await _userRepository.GetUserByRegistration(registrationId);
        if (userToUpdate == null) return NotFound("Usuário não encontrado.");
        
        userToUpdate.Name = user.Name;
        userToUpdate.Email = user.Email;
        userToUpdate.PasswordHash = user.PasswordHash;
        userToUpdate.Address = user.Address;
        userToUpdate.Phone = user.Phone;
        userToUpdate.IsActive = user.IsActive;
        
        _userRepository.Update(userToUpdate);
        return NoContent();
    }

    [HttpDelete("{registrationId:int}")]
    public async Task<IActionResult> Delete(int registrationId)
    {
        var userToDelete = await _userRepository.Delete(registrationId);

        if (!userToDelete) return NotFound("Produto não encontrado.");
        
        return NoContent();
    }

}