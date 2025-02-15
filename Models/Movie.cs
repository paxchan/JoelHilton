using System.ComponentModel.DataAnnotations;

namespace JoelHiltonMovies.Models;

public class Movie
{
    [Key]
    public int Id { get; set; } // Primary key

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, 2025, ErrorMessage = "Year must be between 1888 and 2025.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Director is required.")]
    public string Director { get; set; }

    [Required(ErrorMessage = "Rating is required.")]
    public string Rating { get; set; } // Dropdown values (G, PG, PG-13, R)

    public bool Edited { get; set; } // Boolean checkbox

    public string? Lent { get; set; } // Nullable in case it's empty

    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; } // Nullable with a max length of 25 characters
}