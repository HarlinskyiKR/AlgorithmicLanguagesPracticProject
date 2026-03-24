namespace AlgorithmicLanguagesPracticProject.Models.Entities;

public class Media
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }
    public int StudioId { get; set; }
    public Studio? Studio { get; set; }
    public List<Comment> Comments { get; set; } = [];
}