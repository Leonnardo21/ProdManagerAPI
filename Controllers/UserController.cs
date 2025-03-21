using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdManager.Data;
using ProdManager.Entities;
using ProdManager.Extensions;
using ProdManager.ViewEntities;

namespace ProdManager.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly ProdManagerDbContext _context;

        public UserController(ProdManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return Ok(new ResultViewEntities<List<User>>(users));
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
                var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);

                if (user == null)
                {
                    return NotFound(new ResultViewEntities<User>("PCXE02 - Conteúdo não encotrado"));
                }

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
                    Password = model.Password,
                    Phone = model.Phone,
                    Address = model.Address,
                    Role = model.Role
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

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
                var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);

                if (user == null)
                    return NotFound(new ResultViewEntities<User>("PCXE04 - Conteúdo não encontrado"));

                user.Name = model.Name;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Phone = model.Phone;
                user.Address = model.Address;
                user.Role = model.Role;
              

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return Ok(user);
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
                var users = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (users == null)
                    return NotFound(new ResultViewEntities<User>("PCXE05 - Conteúdo não encontrado"));
                _context.Users.Remove(users);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<User>("PCXE05 - Falha Interna no Servidor"));
            }
        }
    }
}
