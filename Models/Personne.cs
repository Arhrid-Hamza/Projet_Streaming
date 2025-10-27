using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet_Streaming.Models
{
    public abstract class Personne
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }
    }
}