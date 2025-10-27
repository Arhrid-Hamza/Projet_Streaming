using System.Collections.Generic;

namespace Projet_Streaming.Models
{
    public class Serie : Contenu
    {
        public int Saisons { get; set; }
        // Composition: Serie *-- Episode
        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}