using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public class Profil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomProfil { get; set; }

        public int AgeLimite { get; set; }

        public int UtilisateurId { get; set; } // Foreign Key
        public Utilisateur Utilisateur { get; set; }
    }
}