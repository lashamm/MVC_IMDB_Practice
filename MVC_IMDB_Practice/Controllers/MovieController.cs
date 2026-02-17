using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_IMDB_Practice.Data;
using MVC_IMDB_Practice.Models.Entities;

namespace MVC_IMDB_Practice.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext movieContext;

        public MoviesController(MovieDbContext context)
        {
            this.movieContext = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Movie> movies = await movieContext.Movies.ToListAsync();
            return View(movies);
        }

        public async Task<IActionResult> Create()
        {
            List<Movie> movies = await movieContext.Movies.ToListAsync();
            return View(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movieItem)
        {
            await movieContext.AddAsync(movieItem);
            movieContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
