using System;
using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public class Watchlist
    {
        // Composite Key defined in DbContext

        [Required]
        public DateTime DateAjout { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public int ContenuId { get; set; }
        public Contenu Contenu { get; set; }
    }
}