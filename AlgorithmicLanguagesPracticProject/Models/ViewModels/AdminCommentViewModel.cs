namespace AlgorithmicLanguagesPracticProject.Models.ViewModels;

public class AdminCommentViewModel
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int MediaId { get; set; }
    public int UserId { get; set; }
}
