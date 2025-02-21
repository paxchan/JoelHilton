using System.ComponentModel.DataAnnotations;

namespace JoelHiltonMovies.Models;

public class Category
{
    public int CategoryId { get; set; } // Matches DB

    [Required(ErrorMessage = "Category Name is required.")]
    public string CategoryName { get; set; } // Now correctly NOT NULL
}