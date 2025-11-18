using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteoApi.Models
{
    public class Station
    {
        [Key]
        [Column("id_station")]
        public int IdStation { get; set; }

        // Clé étrangère
        [Column("id_ville")]
        public int IdVille { get; set; }

        [Column("nom_station")]
        public string NomStation { get; set; } = string.Empty; // Initialisation pour éviter les warnings

        [Column("latitude", TypeName = "decimal(10, 8)")]
        public decimal Latitude { get; set; }

        [Column("longitude", TypeName = "decimal(11, 8)")]
        public decimal Longitude { get; set; }

        // Relations de navigation (initialisation pour éviter les warnings)
        public Ville Ville { get; set; } = null!; // null! indique que c'est géré par EF Core
        public ICollection<ReleveMeteo> RelevesMeteo { get; set; } = new List<ReleveMeteo>();
    }
}
