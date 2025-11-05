using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchlistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WatchlistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Watchlist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Watchlist>>> GetWatchlists()
        {
            return await _context.Watchlists.ToListAsync();
        }

        // GET: api/Watchlist/5/10 (UtilisateurId/ContenuId)
        [HttpGet("{utilisateurId}/{contenuId}")]
        public async Task<ActionResult<Watchlist>> GetWatchlist(int utilisateurId, int contenuId)
        {
            var watchlist = await _context.Watchlists.FindAsync(utilisateurId, contenuId);

            if (watchlist == null)
            {
                return NotFound();
            }

            return watchlist;
        }

        // PUT: api/Watchlist/5/10
        [HttpPut("{utilisateurId}/{contenuId}")]
        public async Task<IActionResult> PutWatchlist(int utilisateurId, int contenuId, Watchlist watchlist)
        {
            if (utilisateurId != watchlist.UtilisateurId || contenuId != watchlist.ContenuId)
            {
                return BadRequest();
            }

            _context.Entry(watchlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchlistExists(utilisateurId, contenuId))
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

        // POST: api/Watchlist
        [HttpPost]
        public async Task<ActionResult<Watchlist>> PostWatchlist(Watchlist watchlist)
        {
            _context.Watchlists.Add(watchlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatchlist", new { utilisateurId = watchlist.UtilisateurId, contenuId = watchlist.ContenuId }, watchlist);
        }

        // DELETE: api/Watchlist/5/10
        [HttpDelete("{utilisateurId}/{contenuId}")]
        public async Task<IActionResult> DeleteWatchlist(int utilisateurId, int contenuId)
        {
            var watchlist = await _context.Watchlists.FindAsync(utilisateurId, contenuId);
            if (watchlist == null)
            {
                return NotFound();
            }

            _context.Watchlists.Remove(watchlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchlistExists(int utilisateurId, int contenuId)
        {
            return _context.Watchlists.Any(e => e.UtilisateurId == utilisateurId && e.ContenuId == contenuId);
        }
    }
}
