using SmartSchedule.Dtos;
using SmartSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                
                return Ok(users);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar os usuários", null, 500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                
                if (user is null)
                {
                    return NotFound($"Não encontrado usuário para o id: {id}!");
                }
                
                return Ok(user);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar o usuário", null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para o usuário!");
            }

            try
            {
                var user = new User
                {
                    Name = dto.Name,
                    Cpf = dto.Cpf,
                    Email = dto.Email,
                    Cellphone = dto.Cellphone,
                    Username = dto.Username,
                    Password = dto.Password
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao criar o usuário", null, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UserUpdateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para atualização do usuário!");
            }

            try
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound($"Não foi encontrado um funcionário com o ID: {id}!");
                }

                user.Name = dto.Name ?? user.Name;
                user.Cpf = dto.Cpf ?? user.Cpf;
                user.Email = dto.Email ?? user.Email;
                user.Cellphone = dto.Cellphone ?? user.Cellphone;
                user.Username = dto.Username ?? user.Username;
                user.Password = dto.Password ?? user.Password;

                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao atualizar o usuário", null, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound($"Não encontrado usuário para o id: {id}!");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao deletar o usuário", null, 500);
            }
        }
    }
}
