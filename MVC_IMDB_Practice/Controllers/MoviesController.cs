using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_IMDB_Practice.Data;
using MVC_IMDB_Practice.Models.Entities;
using MVC_IMDB_Practice.Services;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

namespace MVC_IMDB_Practice.Controllers
{
    public class MoviesController : Controller
    {
        IMovieService service;

        public MoviesController(IMovieService movieService)
        {
            this.service = movieService;
        }

        public async Task<IActionResult> Index(int? pageSize, int? pageNumber, string? searchTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            int pageCount = pageSize ?? 1;
            int pageN = pageNumber ?? 10;

            var query = await service.GetMoviesAsync();
            IPagedList<Movie> movies = query.ToPagedList(pageN, pageCount);
            //.Skip((pageN - 1) * pageCount).
            //Take(pageCount);


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

           
            //await movieContext.AddAsync(movieItem);
            //movieContext.SaveChanges();
            await service.CreateAsync(movieItem);

            return RedirectToAction("Index");
        }
        [HttpGet]


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //Movie? movieItem = await movieContext.Movies.FindAsync(id);
            Movie? movieItem = await service.GetMovieByIdAsync(id);
            return View(movieItem);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Movie movieItem)
        {
            //movieContext.Remove(movieItem);
            //movieContext.SaveChanges();
            await service.DeleteMovieByIdAsync(movieItem.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //Movie? movieItem = await movieContext.Movies.FindAsync(id);
            Movie? movieItem = await service.GetMovieByIdAsync(id);
            return View(movieItem);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Movie movieItem)
        {
            //movieContext.Update(movieItem);
            //movieContext.SaveChanges();
            await service.UpdateMovieAsync(movieItem.Id, movieItem);
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> view(int id)
        {
            //Movie? movieItem = await movieContext.Movies.FindAsync(id);
            Movie? movieItem = await service.GetMovieByIdAsync(id);
            return View(movieItem);
        }
    }
}
