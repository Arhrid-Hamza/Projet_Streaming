using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbonnementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AbonnementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Abonnement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonnement>>> GetAbonnements()
        {
            return await _context.Abonnements.ToListAsync();
        }

        // GET: api/Abonnement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abonnement>> GetAbonnement(int id)
        {
            var abonnement = await _context.Abonnements.FindAsync(id);

            if (abonnement == null)
            {
                return NotFound();
            }

            return abonnement;
        }

        // PUT: api/Abonnement/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbonnement(int id, Abonnement abonnement)
        {
            if (id != abonnement.Id)
            {
                return BadRequest();
            }

            _context.Entry(abonnement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonnementExists(id))
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

        // POST: api/Abonnement
        [HttpPost]
        public async Task<ActionResult<Abonnement>> PostAbonnement(Abonnement abonnement)
        {
            _context.Abonnements.Add(abonnement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbonnement", new { id = abonnement.Id }, abonnement);
        }

        // DELETE: api/Abonnement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbonnement(int id)
        {
            var abonnement = await _context.Abonnements.FindAsync(id);
            if (abonnement == null)
            {
                return NotFound();
            }

            _context.Abonnements.Remove(abonnement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbonnementExists(int id)
        {
            return _context.Abonnements.Any(e => e.Id == id);
        }
    }
}
