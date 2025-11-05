using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriqueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistoriqueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Historique
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historique>>> GetHistoriques()
        {
            return await _context.Historiques.ToListAsync();
        }

        // GET: api/Historique/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historique>> GetHistorique(int id)
        {
            var historique = await _context.Historiques.FindAsync(id);

            if (historique == null)
            {
                return NotFound();
            }

            return historique;
        }

        // PUT: api/Historique/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorique(int id, Historique historique)
        {
            if (id != historique.Id)
            {
                return BadRequest();
            }

            _context.Entry(historique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriqueExists(id))
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

        // POST: api/Historique
        [HttpPost]
        public async Task<ActionResult<Historique>> PostHistorique(Historique historique)
        {
            _context.Historiques.Add(historique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorique", new { id = historique.Id }, historique);
        }

        // DELETE: api/Historique/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorique(int id)
        {
            var historique = await _context.Historiques.FindAsync(id);
            if (historique == null)
            {
                return NotFound();
            }

            _context.Historiques.Remove(historique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoriqueExists(int id)
        {
            return _context.Historiques.Any(e => e.Id == id);
        }
    }
}
