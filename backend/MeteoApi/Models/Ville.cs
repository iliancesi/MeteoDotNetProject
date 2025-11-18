using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteoApi.Models
{
    public class Ville
    {
        [Key]
        [Column("id_ville")]
        public int IdVille { get; set; }

        [Column("nom_ville")]
        public string NomVille { get; set; } = string.Empty; // Initialisation pour éviter les warnings CS8618

        [Column("code_postal")]
        public string CodePostal { get; set; } = string.Empty; // Initialisation pour éviter les warnings CS8618

        // Relation de navigation (pour éviter le warning CS8618, initialisation)
        public ICollection<Station> Stations { get; set; } = new List<Station>();
    }
}