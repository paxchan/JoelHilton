using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JoelHiltonMovies.Models;
using Microsoft.EntityFrameworkCore;

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
            // Retrieves all categories from the database, orders them alphabetically,
            // and stores them in ViewBag to be used in the form dropdown.
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            // Returns the Movies view with a new empty Movie object for form binding.
            return View("Movies", new Movie());
        }

        // This action method handles the POST request when the user submits a movie.
        // It takes a Movie object (submitted from the form), adds it to the database, 
        // and saves the changes.
        [HttpPost]
        public IActionResult Movies(Movie response)
        {
            if (ModelState.IsValid)
            {
                // Adds the movie to the Movies table in the database.
                _context.Movies.Add(response);
                
                // Saves changes to the database (i.e., the new movie is added).
                _context.SaveChanges();
                
                // After successfully saving the movie, it returns the "Confirmation" view 
                // to notify the user that their submission was successful.
                return View("Confirmation");
            }
            else
            {
                // If the form submission is invalid, reload categories so the dropdown is populated.
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                
                // Return the form with validation errors.
                return View(response);
            }
        }

        // Displays the list of all movies in the database, ordered by year.
        public IActionResult MovieDatabase()
        {
            var movies = _context.Movies
                .Include(x => x.Category) // Includes related category data for each movie.
                .OrderByDescending(x => x.Year) // Orders movies by year in descending order.
                .ThenBy(x => x.Title) // Orders movies alphabetically within each year.
                .ToList();

            return View(movies);
        }

        // This action method is called when the user clicks to edit a movie.
        // It retrieves the movie by its ID and pre-fills the form with its details.
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieves the movie record from the database based on its ID.
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
        
            // Retrieves all categories to populate the dropdown list in the edit form.
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
        
            // Returns the "Movies" view, but with the existing movie details pre-filled for editing.
            return View("Movies", recordToEdit);
        }

        // This action method handles the POST request when the user submits an edited movie.
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            // Updates the existing movie record with the new information.
            _context.Movies.Update(updatedInfo);
            _context.SaveChanges();

            // Redirects the user back to the MovieDatabase page after editing.
            return RedirectToAction("MovieDatabase");
        }

        // This action method is called when the user selects to delete a movie.
        // It loads the movie details for confirmation before deletion.
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Finds the movie record based on the ID.
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
        
            // Returns the delete confirmation view with movie details.
            return View(recordToDelete);
        }

        // This action method handles the actual deletion of a movie when confirmed.
        [HttpPost]
        public IActionResult Delete(Movie recordToDelete)
        {
            // Removes the selected movie from the database.
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();
        
            // Redirects the user back to the MovieDatabase page after deletion.
            return RedirectToAction("MovieDatabase");
        }
    }
}

