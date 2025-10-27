using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_Streaming.Models
{
    public class Paiement
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Montant { get; set; }

        public DateTime DatePaiement { get; set; }

        [Required]
        public string Methode { get; set; }

        public int AbonneId { get; set; } // Foreign Key
        public Abonne Abonne { get; set; }
    }
}