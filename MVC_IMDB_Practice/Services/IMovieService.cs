using MVC_IMDB_Practice.Models.Entities;

namespace MVC_IMDB_Practice.Services
{
    public interface IMovieService
    {
        Task CreateAsync(Movie movie);

        Task UpdateMovieAsync(int id, Movie newMovie);

        Task DeleteMovieByIdAsync(int id);

        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie?> GetMovieByIdAsync(int id);
    }

}
