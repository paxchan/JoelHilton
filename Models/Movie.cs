using System.ComponentModel.DataAnnotations;

namespace JoelHiltonMovies.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; } // Primary key

    public int? CategoryId { get; set; } // Matches DB nullability
    public Category? Category { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } // Matches DB (NOT NULL)

    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, 2025, ErrorMessage = "Year must be between 1888 and 2025.")]
    public int Year { get; set; } // Matches DB (NOT NULL)

    public string? Director { get; set; } // Nullable, matches DB
    public string? Rating { get; set; } // Nullable, matches DB

    public bool Edited { get; set; } // NOT NULL in DB, default false
    public bool CopiedToPlex { get; set; } // NOT NULL in DB, default false

    public string? LentTo { get; set; } // Nullable, matches DB
    public string? Notes { get; set; } // Nullable, matches DB
}