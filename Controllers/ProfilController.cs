using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Profil
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profil>>> GetProfils()
        {
            return await _context.Profils.ToListAsync();
        }

        // GET: api/Profil/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profil>> GetProfil(int id)
        {
            var profil = await _context.Profils.FindAsync(id);

            if (profil == null)
            {
                return NotFound();
            }

            return profil;
        }

        // PUT: api/Profil/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfil(int id, Profil profil)
        {
            if (id != profil.Id)
            {
                return BadRequest();
            }

            _context.Entry(profil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilExists(id))
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

        // POST: api/Profil
        [HttpPost]
        public async Task<ActionResult<Profil>> PostProfil(Profil profil)
        {
            _context.Profils.Add(profil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfil", new { id = profil.Id }, profil);
        }

        // DELETE: api/Profil/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfil(int id)
        {
            var profil = await _context.Profils.FindAsync(id);
            if (profil == null)
            {
                return NotFound();
            }

            _context.Profils.Remove(profil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfilExists(int id)
        {
            return _context.Profils.Any(e => e.Id == id);
        }
    }
}
