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
        
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            
                new Category {CategoryId=1, CategoryName = "Miscellaneous"},
                new Category {CategoryId=2, CategoryName = "Drama"},
                new Category {CategoryId=3, CategoryName = "Television"},
                new Category {CategoryId=4, CategoryName = "Horror/Suspense"},
                new Category {CategoryId=5, CategoryName = "Comedy"},
                new Category {CategoryId=6, CategoryName = "Family"},
                new Category {CategoryId=7, CategoryName = "Action/Adventure"},
                new Category {CategoryId=8, CategoryName = "VHS"}
            
            );
        }
    }
}
