using Microsoft.AspNetCore.Mvc;
using SmartSchedule.Models;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;
using SmartSchedule.Dtos;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("assigned")]
    public class AssignedController : Controller
    {
        private readonly SmartScheduleContext _context;

        public AssignedController(SmartScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var assigned = await _context.Assigned
                    .Include(a => a.Member)
                    .ThenInclude(m => m.User)
                    .Include(a => a.Assignment)
                    .Include(a => a.Scheduled).Include(assigned => assigned.Member).ThenInclude(member => member.Team)
                    .ToListAsync();
                
                var assignedDto = assigned.Select(a => new AssignedDto
                {
                    Id = a.Id,
                    Member = a.Member != null ? new MemberDto
                    {
                        Id = a.Member.Id,
                        UserName = a.Member.User != null ? a.Member.User.Name : "Usuário Desconhecido",
                        TeamName = a.Member.Team != null ? a.Member.Team.Name : "Time Desconhecido"
                        
                    } : null, // Se Member for null, retorna null

                    Assignment = a.Assignment != null ? new AssignmentDto
                    {
                        Id = a.Assignment.Id,
                        Name = a.Assignment.Name
                    } : null, // Se Assignment for null, retorna null

                    Scheduled = a.Scheduled != null ? new ScheduledDto
                    {
                        Id = a.Scheduled.Id,
                        Name = a.Scheduled.Name,
                        Start = a.Scheduled.Start,
                        End = a.Scheduled.End
                    } : null // Se Scheduled for null, retorna null
                }).ToList();
                
                return Ok(assignedDto);
            }   
            catch (Exception)
            {
                return Problem("Erro Inesperado ao buscar tarefas", null, 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var assigned = await _context.Assigned.FindAsync(id);
                if (assigned == null)
                {
                    return NotFound();
                }
                return Ok(assigned);
            }
            catch (Exception)
            {
                return Problem("Erro Inesperado ao buscar tarefa", null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Assigned assigned)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Assigned.Add(assigned);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = assigned.AssignmentId }, assigned);
            }
            catch (Exception)
            {
                return Problem("Erro Inesperado ao criar Tafera", null, 500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Assigned assigned)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAssigned = await _context.Assigned.FindAsync(id);
            if (existingAssigned == null)
            {
                return NotFound();
            }

            existingAssigned.Member = assigned.Member;
            existingAssigned.Assignment = assigned.Assignment;

            try
            {
                _context.Assigned.Update(existingAssigned);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao atualizar tarefa", null, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var assigned = await _context.Assigned.FindAsync(id);
            if (assigned == null)
            {
                return NotFound();
            }

            try
            {
                _context.Assigned.Remove(assigned);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return Problem("Unexpected error occurred while deleting the assignment", null, 500);
            }
        }
    }
}
