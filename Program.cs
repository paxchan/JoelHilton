using JoelHiltonMovies.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adds the services required for MVC, including controllers and views.
builder.Services.AddControllersWithViews();

// Configures the SQLite database connection using the connection string from appsettings.json.
// The "MovieConnection" string in the configuration file is used to specify the connection to the SQLite database.
builder.Services.AddDbContext<MovieDatabaseContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Configures the application to use exception handling in non-development environments (e.g., production).
    app.UseExceptionHandler("/Home/Error");

    // Configures HTTP Strict Transport Security (HSTS) for added security in production.
    // This forces clients to communicate with the server over HTTPS.
    app.UseHsts();
}

// Ensures that requests are redirected to HTTPS for security.
app.UseHttpsRedirection();

// Serves static files (e.g., CSS, images, JavaScript).
app.UseStaticFiles();

// Configures routing so that HTTP requests can be matched to appropriate controllers and actions.
app.UseRouting();

// Enables authorization (if required for the app).
app.UseAuthorization();

// Defines the default route for controllers and actions.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Starts the application and begins listening for incoming HTTP requests.
app.Run();
