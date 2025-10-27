using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }
        public ICollection<ContentGenre> ContentGenres { get; set; } = new List<ContentGenre>();
    }
}