using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }
        public ICollection<Contenu> Contenus { get; set; } = new List<Contenu>();
    }
}