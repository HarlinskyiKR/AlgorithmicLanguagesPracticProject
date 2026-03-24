namespace AlgorithmicLanguagesPracticProject.Models.Entities;

public class Studio
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public List<Media> Medias { get; set; } = [];
}
