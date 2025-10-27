namespace Projet_Streaming.Models
{
    public class ContentGenre
    {
        // Composite Key defined in DbContext
        public int ContenuId { get; set; }
        public Contenu Contenu { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}