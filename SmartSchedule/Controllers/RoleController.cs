using SmartSchedule.Dtos;
using SmartSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchedule.DataContext;
using Microsoft.EntityFrameworkCore;

namespace SmartSchedule.Controllers
{
    [ApiController]
    [Route("role")]
    public class RoleController : Controller
    {
        private readonly SmartScheduleContext _context;

        public RoleController(SmartScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var teams = await _context.Roles.ToListAsync();

                return Ok(teams);
            }
            catch (Exception)
            {
                return Problem("Erro inesperado ao buscar os papéis", null, 500);
            }
        }
    }
}
