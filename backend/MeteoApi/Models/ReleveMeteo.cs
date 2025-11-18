using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteoApi.Models
{
    public class ReleveMeteo
    {
        [Key]
        [Column("id_releve")]
        public int IdReleve { get; set; }

        [Column("id_station")]
        public int IdStation { get; set; }

        [Column("horodatage")]
        public DateTime Horodatage { get; set; }

        [Column("temperature_celsius", TypeName = "decimal(5, 2)")]
        public decimal TemperatureCelsius { get; set; }

        // Note: Le '?' permet que la valeur soit NULL en BDD
        [Column("humidite_pourcentage", TypeName = "decimal(5, 2)")]
        public decimal? HumiditePourcentage { get; set; }

        [Column("vitesse_vent_kmh", TypeName = "decimal(5, 2)")]
        public decimal? VitesseVentKmh { get; set; }

        // Relation de navigation (initialisation pour éviter les warnings)
        public Station Station { get; set; } = null!; // null! indique que c'est géré par EF Core
    }
}