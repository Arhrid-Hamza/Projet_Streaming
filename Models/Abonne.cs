using System;
using System.Collections.Generic;

namespace Projet_Streaming.Models
{
    public class Abonne : Utilisateur
    {
        public DateTime DateExpiration { get; set; }

        // 1-to-1 Association
        public int? AbonnementId { get; set; }
        public Abonnement Abonnement { get; set; }

        // 1-to-Many Association
        public ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
    }
}