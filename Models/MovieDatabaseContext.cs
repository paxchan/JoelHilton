using Microsoft.EntityFrameworkCore;

namespace JoelHiltonMovies.Models
{
    // MovieDatabaseContext inherits from DbContext and is used to interact with the database.
    // It contains the DbSet properties for the entities in the database, in this case, the "Movies" table.
    public class MovieDatabaseContext : DbContext
    {
        // The constructor accepts DbContextOptions for the MovieDatabaseContext.
        // These options are passed to the base class (DbContext) to configure the context.
        // This allows it to set up things like the database provider, connection strings, etc.
        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
        {
            // The base constructor call sets up the configuration needed for interacting with the database.
        }
        
        // DbSet<Movie> represents the "Movies" table in the database.
        // It is a collection of Movie entities, which allows you to query, add, update, or delete movies.
        public DbSet<Movie> Movies { get; set; }
    }
}
