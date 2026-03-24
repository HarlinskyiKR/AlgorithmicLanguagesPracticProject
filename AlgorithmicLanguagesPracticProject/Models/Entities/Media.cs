namespace AlgorithmicLanguagesPracticProject.Models.Entities;

public class Media
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    // Foreign key to Genre
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Directors { get; set; } = string.Empty;
    public string Actors { get; set; } = string.Empty;
    public string PlayerIframeUrl { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }
    public int StudioId { get; set; }
    public Studio? Studio { get; set; }
    public List<Comment> Comments { get; set; } = [];
}