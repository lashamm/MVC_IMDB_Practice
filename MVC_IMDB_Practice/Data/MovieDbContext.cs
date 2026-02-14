using Microsoft.EntityFrameworkCore;
using MVC_IMDB_Practice.Models.Entities;

namespace MVC_IMDB_Practice.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {
        }

        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Entities.Movie> Movie { get; set; }
    }
}
