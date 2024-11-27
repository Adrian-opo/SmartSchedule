using SmartSchedule.Dtos;
using SmartSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("functionary")]

    public class FunctionaryController : Controller
    {
        private readonly AppDbContext _context;

        public FunctionaryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var functionarys = await _context.Functionaries.ToListAsync();

                return Ok(functionarys);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar os funcionários", null, 500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try {
                var functionary = await _context.Functionaries.FindAsync(id);

                if (functionary is null)
                {
                    return NotFound($"Não encontrado funcionário para o id: {id}!");
                }

                return Ok(functionary);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar o funcionário", null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FunctionaryCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para cadastro do funcionário");
            }

            try
            {
                var functionary = new Functionary
                {
                    Name = dto.Name,
                    Cpf = dto.Cpf,
                    Siape = dto.Siape
                };

                _context.Functionaries.Add(functionary);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = functionary.Id }, functionary);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao cadastrar o funcionário", null, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FunctionaryUpdateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para atualização do funcionário");
            }

            try
            {
                var functionary = await _context.Functionaries.FindAsync(id);

                if (functionary == null)
                {
                    return NotFound($"Não foi encontrado um funcionário com o ID: {id}!");
                }

                functionary.Name = dto.Name ?? functionary.Name;
                functionary.Cpf = dto.Cpf ?? functionary.Cpf;
                functionary.Siape = dto.Siape ?? functionary.Siape;
                
                await _context.SaveChangesAsync();

                return Ok(functionary);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao atualizar funcionário: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var functionary = await _context.Functionaries.FindAsync(id);
                if (functionary == null)
                {
                    return NotFound($"Não encontrado funcionário para o id: {id}!");
                }

                _context.Functionaries.Remove(functionary);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao deletar o funcionário", null, 500);
            }
        }
    }
}
