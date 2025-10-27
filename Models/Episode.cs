using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public class Episode
    {
        [Key]
        public int Id { get; set; }
        public int NumEpisode { get; set; }
        public int Saison { get; set; }
        public string Titre { get; set; }
        public string VideoUrl { get; set; }

        public int SerieId { get; set; } // Foreign Key
        public Serie Serie { get; set; }
    }
}