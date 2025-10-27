using System;
using System.Collections.Generic;

namespace Projet_Streaming.Models
{
    public class Utilisateur : Personne
    {
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Profil> Profils { get; set; } = new List<Profil>();
        public ICollection<Historique> Historiques { get; set; } = new List<Historique>();
        public ICollection<Watchlist> WatchlistItems { get; set; } = new List<Watchlist>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}