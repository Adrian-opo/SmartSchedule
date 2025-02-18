using Microsoft.AspNetCore.Mvc;
using SmartSchedule.Models;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

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
                var assigned = await _context.Assigned.ToListAsync();
                return Ok(assigned);
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
