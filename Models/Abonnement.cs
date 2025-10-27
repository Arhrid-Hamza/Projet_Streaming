using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_Streaming.Models
{
    public class Abonnement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Prix { get; set; }
    }
}