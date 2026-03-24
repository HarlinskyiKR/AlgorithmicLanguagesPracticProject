namespace AlgorithmicLanguagesPracticProject.Models.ViewModels;

public class MediaDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string GenreName { get; set; } = string.Empty; // Назва жанру
    public string Country { get; set; } = string.Empty;
    public string Directors { get; set; } = string.Empty;
    public string Actors { get; set; } = string.Empty;
    public string PlayerIframeUrl { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

    public List<MediaCommentViewModel> Comments { get; set; } = [];
}
