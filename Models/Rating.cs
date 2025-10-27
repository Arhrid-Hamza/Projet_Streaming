using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 5)]
        public int Note { get; set; }

        public string Commentaire { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public int ContenuId { get; set; }
        public Contenu Contenu { get; set; }
    }
}