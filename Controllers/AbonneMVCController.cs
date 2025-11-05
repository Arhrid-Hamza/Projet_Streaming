using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;

namespace Projet_Streaming.Controllers
{
    public class AbonneMVCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbonneMVCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Abonne
        public async Task<IActionResult> Index()
        {
            var abonnes = await _context.Abonnes
                .Include(a => a.Abonnement)
                .ToListAsync();
            return View(abonnes);
        }

        // GET: Abonne/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonne = await _context.Abonnes
                .Include(a => a.Abonnement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abonne == null)
            {
                return NotFound();
            }

            return View(abonne);
        }

        // GET: Abonne/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abonne/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Email,PasswordHash,Role,DateCreation,DateExpiration,AbonnementId")] Abonne abonne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abonne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abonne);
        }

        // GET: Abonne/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonne = await _context.Abonnes.FindAsync(id);
            if (abonne == null)
            {
                return NotFound();
            }
            return View(abonne);
        }

        // POST: Abonne/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Email,PasswordHash,Role,DateCreation,DateExpiration,AbonnementId")] Abonne abonne)
        {
            if (id != abonne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abonne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonneExists(abonne.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(abonne);
        }

        // GET: Abonne/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonne = await _context.Abonnes
                .Include(a => a.Abonnement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abonne == null)
            {
                return NotFound();
            }

            return View(abonne);
        }

        // POST: Abonne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abonne = await _context.Abonnes.FindAsync(id);
            if (abonne != null)
            {
                _context.Abonnes.Remove(abonne);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbonneExists(int id)
        {
            return _context.Abonnes.Any(e => e.Id == id);
        }
    }
}
