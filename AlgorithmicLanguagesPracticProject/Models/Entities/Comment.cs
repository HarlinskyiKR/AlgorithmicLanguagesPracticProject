namespace AlgorithmicLanguagesPracticProject.Models.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int MediaId { get; set; }
    public int UserId { get; set; }
}
