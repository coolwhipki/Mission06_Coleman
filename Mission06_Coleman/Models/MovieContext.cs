using Microsoft.EntityFrameworkCore;

namespace Mission06_Coleman.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<Movie> CinemaSlay { get; set; }
    }
}
