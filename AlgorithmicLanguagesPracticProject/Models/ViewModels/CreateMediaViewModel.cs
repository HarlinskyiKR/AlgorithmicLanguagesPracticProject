using System.ComponentModel.DataAnnotations;

using AlgorithmicLanguagesPracticProject.Models.Entities;
namespace AlgorithmicLanguagesPracticProject.Models.ViewModels;

public class CreateMediaViewModel
{

    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(3000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Жанр")]
    public int GenreId { get; set; }

    public IEnumerable<Genre>? Genres { get; set; }

    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Directors { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string Actors { get; set; } = string.Empty;

    [Required]
    [Url]
    [MaxLength(2048)]
    public string PlayerIframeUrl { get; set; } = string.Empty;

    [Required]
    [Url]
    [MaxLength(2048)]
    public string PosterUrl { get; set; } = string.Empty;

    [Range(1900, 2200)]
    public int ReleaseYear { get; set; } = DateTime.UtcNow.Year;

    [Range(0, 10)]
    public double Rating { get; set; }

    public int StudioId { get; set; } = 1;
}
