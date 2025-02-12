using SmartSchedule.Dtos;
using SmartSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("scheduled")]
    public class ScheduledController : Controller
    {
        private readonly SmartScheduleContext _context;

        public ScheduledController(SmartScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var scheduleds = await _context.Scheduleds.ToListAsync();

                return Ok(scheduleds);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar os agendamentos", null, 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var scheduled = await _context.Scheduleds.FindAsync(id);

                if (scheduled is null)
                {
                    return NotFound($"Não encontrado um agendamento com o ID: {id}!");
                }

                return Ok(scheduled);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar o agendamento", null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScheduledCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para o agendamento!");
            }

            try
            {
                var scheduled = new Scheduled
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Start = dto.Start,
                    End = dto.End,
                };

                _context.Scheduleds.Add(scheduled);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = scheduled.Id }, dto);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao criar o agendamento", null, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, ScheduledUpdateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para atualização do agendamento!");
            }

            try
            {
                var scheduled = await _context.Scheduleds.FindAsync(id);

                if (scheduled == null)
                {
                    return NotFound($"Não foi encontrado um agendamento com o ID: {id}!");
                }

                scheduled.Name = dto.Name;
                scheduled.Description = dto.Description;
                scheduled.Start = dto.Start;
                scheduled.End = dto.End;

                await _context.SaveChangesAsync();
                return Ok(scheduled);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao atualizar o agendamento", null, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var scheduled = await _context.Scheduleds.FindAsync(id);
                if (scheduled == null)
                    return NotFound("Agendamento não encontrado");

                _context.Scheduleds.Remove(scheduled);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao deletar o agendamento", null, 500);
            }
        }
    }
}
