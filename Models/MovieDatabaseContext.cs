using Microsoft.EntityFrameworkCore;

namespace JoelHiltonMovies.Models;

public class MovieDatabaseContext : DbContext
{
    public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
    {
        
    }
    public DbSet<Movie> Movies { get; set; }
}