using System.ComponentModel.DataAnnotations;

namespace AlgorithmicLanguagesPracticProject.Models.ViewModels;

public class CreateMediaViewModel
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(3000)]
    public string Description { get; set; } = string.Empty;

    [Range(1900, 2200)]
    public int ReleaseYear { get; set; } = DateTime.UtcNow.Year;

    [Range(0, 10)]
    public double Rating { get; set; }

    public int StudioId { get; set; } = 1;
}
