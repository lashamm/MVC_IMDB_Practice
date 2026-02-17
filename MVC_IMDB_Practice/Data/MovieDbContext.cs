using Microsoft.EntityFrameworkCore;
using MVC_IMDB_Practice.Models.Entities;

namespace MVC_IMDB_Practice.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MovieDbContext()
        {
        }
    }
}
