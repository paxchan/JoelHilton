using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JoelHiltonMovies.Models;

namespace JoelHiltonMovies.Controllers
{
    // The HomeController is responsible for handling the requests and actions related to the home pages of the website.
    public class HomeController : Controller
    {
        // _context is used to interact with the MovieDatabaseContext (which is your database).
        private MovieDatabaseContext _context;
        
        // The constructor takes a MovieDatabaseContext as a parameter, which is injected using dependency injection.
        // This allows the controller to interact with the database.
        public HomeController(MovieDatabaseContext temp)
        {
            _context = temp;
        }

        // This action method is called when the user accesses the home page.
        // It returns the "Index" view, which typically displays the homepage content.
        public IActionResult Index()
        {
            return View();
        }

        // This action method is called when the user accesses the "GetToKnowJoel" page.
        // It returns the "GetToKnowJoel" view, which is a personal introduction page.
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // This action method is called when the user accesses the "Movies" page via a GET request.
        // It returns the "Movies" view, which likely displays the form to submit movie information.
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        // This action method handles the POST request when the user submits a movie.
        // It takes a Movie object (submitted from the form), adds it to the database, 
        // and saves the changes.
        [HttpPost]
        public IActionResult Movies(Movie response)
        {
            // Adds the movie to the Movies table in the database.
            _context.Movies.Add(response);
            
            // Saves changes to the database (i.e., the new movie is added).
            _context.SaveChanges();
            
            // After successfully saving the movie, it returns the "Confirmation" view 
            // to notify the user that their submission was successful.
            return View("Confirmation");
        }
    }
}
