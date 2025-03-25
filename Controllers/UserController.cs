using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdManager.Data;
using ProdManager.Entities;
using ProdManager.Extensions;
using ProdManager.Repositories.Interface;
using ProdManager.ViewEntities;

namespace ProdManager.Controllers
{
    [ApiController]
    [Route("v1")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                return Ok(new ResultViewEntities<List<User>>(users.ToList()));
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<User>("PCXE01 - Falha Interna no Servidor"));
            }
        }

        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);

                if (user == null)
                    return NotFound(new ResultViewEntities<User>("PCXE02 - Conteúdo não encotrado"));


                return Ok(new ResultViewEntities<User>(user));
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<User>("PCXE02 - Falha Interna no Servidor"));
            }
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> PostAsync([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewEntities<User>(ModelState.GetErrors()));

            try
            {
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Registration = model.Registration,
                    Password = model.Password,
                    Phone = model.Phone,
                    Address = model.Address,
                    Role = model.Role
                };

                await _userRepository.AddUserAsync(user);
                return Created($"v1/users/{user.Id}", new ResultViewEntities<User>(user));
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<User>("PCXE03 - Falha Interna no Servidor"));
            }
        }

        [HttpPut]
        [Route("users/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] User model)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);

                if (user == null)
                    return NotFound(new ResultViewEntities<User>("PCXE04 - Conteúdo não encontrado"));

                user.Name = model.Name;
                user.Email = model.Email;
                user.Registration = model.Registration;
                user.Password = model.Password;
                user.Phone = model.Phone;
                user.Address = model.Address;
                user.Role = model.Role;


                await _userRepository.UpdateUserAsync(user);
                return Ok(new ResultViewEntities<User>(user));
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<User>("PCXE04 - Falha Interna no Servidor"));
            }
        }

        [HttpDelete]
        [Route("users/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var users = await _userRepository.GetUserByIdAsync(id);
                if (users == null)
                    return NotFound(new ResultViewEntities<User>("PCXE05 - Conteúdo não encontrado"));
                await _userRepository.DeleteUserAsync(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<User>("PCXE05 - Falha Interna no Servidor"));
            }
        }
    }
}