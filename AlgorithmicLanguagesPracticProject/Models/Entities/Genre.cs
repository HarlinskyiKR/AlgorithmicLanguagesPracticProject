using System.Collections.Generic;

namespace AlgorithmicLanguagesPracticProject.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Media> Media { get; set; } = new List<Media>();
    }
}