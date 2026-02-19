using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_IMDB_Practice.Data;
using MVC_IMDB_Practice.Models.Entities;

namespace MVC_IMDB_Practice.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext movieContext;

        public MovieService()
        {
        }

        public MovieService(MovieDbContext movieContext)
        {
            this.movieContext = movieContext;
        }

        public async Task CreateAsync(Movie movie)
        {
            await movieContext.Movies.AddAsync(movie);
            await movieContext.SaveChangesAsync();
        }
        public async Task DeleteMovieByIdAsync(int id)
        {
            await movieContext.Movies.Where(m => m.Id == id).ExecuteDeleteAsync();
            await movieContext.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            await movieContext.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
             return await movieContext.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            await movieContext.Movies.ToListAsync();
            return await movieContext.Movies.ToListAsync();
        }

        public async Task UpdateMovieAsync(int id, Movie newMovie)
        {
            await movieContext.Movies.Where(m => m.Id == id).ExecuteUpdateAsync(m => m
                .SetProperty(p => p.Title, newMovie.Title)
                .SetProperty(p => p.Genre, newMovie.Genre)
                .SetProperty(p => p.ReleaseYear, newMovie.ReleaseYear)
                .SetProperty(p => p.Director, newMovie.Director)
                .SetProperty(p => p.Duration, newMovie.Duration));
             await movieContext.SaveChangesAsync();
        }
    }
}
