using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentGenreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContentGenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContentGenre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentGenre>>> GetContentGenres()
        {
            return await _context.ContentGenres.ToListAsync();
        }

        // GET: api/ContentGenre/5/10 (ContenuId/GenreId)
        [HttpGet("{contenuId}/{genreId}")]
        public async Task<ActionResult<ContentGenre>> GetContentGenre(int contenuId, int genreId)
        {
            var contentGenre = await _context.ContentGenres.FindAsync(contenuId, genreId);

            if (contentGenre == null)
            {
                return NotFound();
            }

            return contentGenre;
        }

        // PUT: api/ContentGenre/5/10
        [HttpPut("{contenuId}/{genreId}")]
        public async Task<IActionResult> PutContentGenre(int contenuId, int genreId, ContentGenre contentGenre)
        {
            if (contenuId != contentGenre.ContenuId || genreId != contentGenre.GenreId)
            {
                return BadRequest();
            }

            _context.Entry(contentGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentGenreExists(contenuId, genreId))
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

        // POST: api/ContentGenre
        [HttpPost]
        public async Task<ActionResult<ContentGenre>> PostContentGenre(ContentGenre contentGenre)
        {
            _context.ContentGenres.Add(contentGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentGenre", new { contenuId = contentGenre.ContenuId, genreId = contentGenre.GenreId }, contentGenre);
        }

        // DELETE: api/ContentGenre/5/10
        [HttpDelete("{contenuId}/{genreId}")]
        public async Task<IActionResult> DeleteContentGenre(int contenuId, int genreId)
        {
            var contentGenre = await _context.ContentGenres.FindAsync(contenuId, genreId);
            if (contentGenre == null)
            {
                return NotFound();
            }

            _context.ContentGenres.Remove(contentGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentGenreExists(int contenuId, int genreId)
        {
            return _context.ContentGenres.Any(e => e.ContenuId == contenuId && e.GenreId == genreId);
        }
    }
}
