using MVC_IMDB_Practice.Data;
using MVC_IMDB_Practice.Models.Entities;

namespace MVC_IMDB_Practice.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext movieContext;

        public MovieService(MovieDbContext movieContext)
        {
            this.movieContext = movieContext;
        }

        public Task CreateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieAsync(int id, Movie newMovie)
        {
            throw new NotImplementedException();
        }
    }

}
