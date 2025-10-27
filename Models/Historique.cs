using System;
using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public class Historique
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateLecture { get; set; }

        public float Progression { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public int ContenuId { get; set; }
        public Contenu Contenu { get; set; }

        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
    }
}