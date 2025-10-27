using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public abstract class Contenu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titre { get; set; }
        public string Description { get; set; }
        public int Duree { get; set; }
        public DateTime DateSortie { get; set; }
        public string ThumbnailUrl { get; set; }

        // 1-to-1 Association to Category
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        // Many-to-Many Association join collection
        public ICollection<ContentGenre> ContentGenres { get; set; } = new List<ContentGenre>();
    }
}