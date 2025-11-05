using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbonneController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AbonneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Abonne
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonne>>> GetAbonnes()
        {
            return await _context.Abonnes.ToListAsync();
        }

        // GET: api/Abonne/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abonne>> GetAbonne(int id)
        {
            var abonne = await _context.Abonnes.FindAsync(id);

            if (abonne == null)
            {
                return NotFound();
            }

            return abonne;
        }

        // PUT: api/Abonne/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbonne(int id, Abonne abonne)
        {
            if (id != abonne.Id)
            {
                return BadRequest();
            }

            _context.Entry(abonne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonneExists(id))
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

        // POST: api/Abonne
        [HttpPost]
        public async Task<ActionResult<Abonne>> PostAbonne(Abonne abonne)
        {
            _context.Abonnes.Add(abonne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbonne", new { id = abonne.Id }, abonne);
        }

        // DELETE: api/Abonne/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbonne(int id)
        {
            var abonne = await _context.Abonnes.FindAsync(id);
            if (abonne == null)
            {
                return NotFound();
            }

            _context.Abonnes.Remove(abonne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbonneExists(int id)
        {
            return _context.Abonnes.Any(e => e.Id == id);
        }
    }
}
