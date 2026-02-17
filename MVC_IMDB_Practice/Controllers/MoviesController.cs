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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movieItem)
        {
            await movieContext.AddAsync(movieItem);
            movieContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Movie? movieItem = await movieContext.Movies.FindAsync(id);
            return View(movieItem);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Movie movieItem)
        {
            movieContext.Remove(movieItem);
            movieContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Movie? movieItem = await movieContext.Movies.FindAsync(id);
            return View(movieItem);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Movie movieItem)
        {
            movieContext.Update(movieItem);
            movieContext.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> view(int id)
        {
            Movie? movieItem = await movieContext.Movies.FindAsync(id);
            return View(movieItem);
        }
    }
}
