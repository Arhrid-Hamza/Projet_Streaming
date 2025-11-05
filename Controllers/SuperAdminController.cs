using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperAdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuperAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SuperAdmin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperAdmin>>> GetSuperAdmins()
        {
            return await _context.SuperAdmins.ToListAsync();
        }

        // GET: api/SuperAdmin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperAdmin>> GetSuperAdmin(int id)
        {
            var superAdmin = await _context.SuperAdmins.FindAsync(id);

            if (superAdmin == null)
            {
                return NotFound();
            }

            return superAdmin;
        }

        // PUT: api/SuperAdmin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperAdmin(int id, SuperAdmin superAdmin)
        {
            if (id != superAdmin.Id)
            {
                return BadRequest();
            }

            _context.Entry(superAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperAdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SuperAdmin
        [HttpPost]
        public async Task<ActionResult<SuperAdmin>> PostSuperAdmin(SuperAdmin superAdmin)
        {
            _context.SuperAdmins.Add(superAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperAdmin", new { id = superAdmin.Id }, superAdmin);
        }

        // DELETE: api/SuperAdmin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperAdmin(int id)
        {
            var superAdmin = await _context.SuperAdmins.FindAsync(id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            _context.SuperAdmins.Remove(superAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperAdminExists(int id)
        {
            return _context.SuperAdmins.Any(e => e.Id == id);
        }
    }
}
