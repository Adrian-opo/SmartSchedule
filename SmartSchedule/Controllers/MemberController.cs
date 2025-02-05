using SmartSchedule.Dtos;
using SmartSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("member")]
    public class MemberController : Controller
    {
        private readonly SmartScheduleContext _context;

        public MemberController(SmartScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var members = await _context.Members
                    .Include(m => m.User)
                    .Include(m => m.Team)
                    .Include(m => m.Role)
                    .Select(m => new MemberDto
                    {
                        Id = m.Id,
                        UserId = m.UserId,
                        UserName = m.User.Name,
                        TeamId = m.TeamId,
                        TeamName = m.Team.Name,
                        TeamDescription = m.Team.Description,
                        RoleId = m.RoleId,
                        RoleName = m.Role.Name,
                        RoleDescription = m.Role.Description
                    })
                    .ToListAsync();

                return Ok(members);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar os membros", null, 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var member = await _context.Members
                    .Include(m => m.User)
                    .Include(m => m.Team)
                    .Include(m => m.Role)
                    .Where(m => m.Id == id)
                    .Select(m => new MemberDto
                    {
                        Id = m.Id,
                        UserId = m.UserId,
                        UserName = m.User.Name,
                        TeamId = m.TeamId,
                        TeamName = m.Team.Name,
                        TeamDescription = m.Team.Description,
                        RoleId = m.RoleId,
                        RoleName = m.Role.Name,
                        RoleDescription = m.Role.Description
                    })
                    .FirstOrDefaultAsync();

                if (member is null)
                {
                    return NotFound($"Não encontrado um membro com o ID: {id}!");
                }

                return Ok(member);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar o membro", null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para o membro!");
            }

            try
            {
                var member = new Member
                {
                    RoleId = dto.RoleId,
                    UserId = dto.UserId,
                    TeamId = dto.TeamId
                };

                _context.Members.Add(member);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = member.Id }, dto);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao criar o membro", null, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, MemberUpdateDto dto)
        {
            if (dto is null)
            {
                return BadRequest("Dados inválidos para atualização do membro!");
            }

            try
            {
                var member = await _context.Members.FindAsync(id);

                if (member == null)
                {
                    return NotFound($"Não foi encontrado um membro com o ID: {id}!");
                }

                member.RoleId = dto.RoleId;
                member.UserId = dto.UserId;
                member.TeamId = dto.TeamId;

                await _context.SaveChangesAsync();
                return Ok(member);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao atualizar o membro", null, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var member = await _context.Members.FindAsync(id);
                if (member == null)
                    return NotFound("Membro não encontrado");

                _context.Members.Remove(member);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao deletar o membro", null, 500);
            }
        }
    }
}
