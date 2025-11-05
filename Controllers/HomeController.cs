using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_Streaming.Data;
using Projet_Streaming.Models;
using System.Linq;
using System.Diagnostics;

namespace Projet_Streaming.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var films = await _context.Contenus.OfType<Film>()
                .Include(f => f.Categorie)
                .Include(f => f.ContentGenres).ThenInclude(cg => cg.Genre)
                .Take(10)
                .ToListAsync();

            var series = await _context.Contenus.OfType<Serie>()
                .Include(s => s.Categorie)
                .Include(s => s.ContentGenres).ThenInclude(cg => cg.Genre)
                .Take(10)
                .ToListAsync();

            var categories = await _context.Categories
                .Include(c => c.Contenus)
                .Take(6)
                .ToListAsync();

            var viewModel = new HomeViewModel
            {
                FeaturedFilms = films,
                FeaturedSeries = series,
                Categories = categories
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class HomeViewModel
    {
        public IEnumerable<Film> FeaturedFilms { get; set; }
        public IEnumerable<Serie> FeaturedSeries { get; set; }
        public IEnumerable<Categorie> Categories { get; set; }
    }
}
