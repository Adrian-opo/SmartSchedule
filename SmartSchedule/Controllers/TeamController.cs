﻿using SmartSchedule.Dtos;
using SmartSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("team")]
    public class TeamController : Controller
    {
        private readonly SmartScheduleContext _context;

        public TeamController(SmartScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var teams = await _context.Teams.ToListAsync();

                return Ok(teams);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar os times", null, 500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var team = await _context.Teams.FindAsync(id);
                if (team is null)
                {
                    return NotFound($"Não encontrado time para o id: {id}!");
                }
                return Ok(team);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar o time", null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para o time!");
            }

            try
            {
                var team = new Team
                {
                    Name = dto.Name,
                    Description = dto.Description
                };

                _context.Teams.Add(team);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao criar o time", null, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] TeamCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para o time!");
            }

            try
            {
                var team = await _context.Teams.FindAsync(id);
                
                if (team is null)
                {
                    return NotFound($"Não encontrado time para o id: {id}!");
                }

                team.Name = dto.Name;
                team.Description = dto.Description;

                await _context.SaveChangesAsync();
                return Ok(team);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao atualizar o time", null, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var team = await _context.Teams.FindAsync(id);
                if (team is null)
                {
                    return NotFound($"Não encontrado time para o id: {id}!");
                }

                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao deletar o time", null, 500);
            }
        }
    }
}
