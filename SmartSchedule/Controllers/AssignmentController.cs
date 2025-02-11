using Microsoft.AspNetCore.Mvc;
using SmartSchedule.Dtos;
using SmartSchedule.Models;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("assignment")]
    public class AssignmentController : Controller
    {
        private readonly SmartScheduleContext _context;

        public AssignmentController(SmartScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var assignments = await _context.Assignments.ToListAsync();
                return Ok(assignments);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar as atribuições", null, 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var assignment = await _context.Assignments.FindAsync(id);
                if (assignment == null)
                {
                    return NotFound();
                }
                return Ok(assignment);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar a atribuição", null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AssignmentDto assignmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = new Assignment
            {
                Name = assignmentDto.Name,
                Description = assignmentDto.Description
            };

            try
            {
                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = assignment.Id }, assignment);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao criar a atribuição", null, 500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AssignmentDto assignmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            assignment.Name = assignmentDto.Name;
            assignment.Description = assignmentDto.Description;

            try
            {
                _context.Assignments.Update(assignment);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao atualizar a atribuição", null, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            try
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao deletar a atribuição", null, 500);
            }
        }
    }
}
