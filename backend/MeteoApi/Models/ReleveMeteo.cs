using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteoApi.Models
{
	// La classe ReleveMeteo correspond à la table RelevesMeteo
	public class ReleveMeteo
	{
		// Clé primaire
		public int IdReleve { get; set; }

		// Clé étrangère (FK) vers la table Stations
		public int IdStation { get; set; }

		// Colonnes de la table
		public DateTime Horodatage { get; set; }

		// Utilisation de [Column] pour s'assurer que le type DECIMAL est bien géré par MySQL
		[Column(TypeName = "decimal(5, 2)")]
		public decimal TemperatureCelsius { get; set; }

		// Le '?' permet que la valeur soit NULL en BDD
		[Column(TypeName = "decimal(5, 2)")]
		public decimal? HumiditePourcentage { get; set; }

		[Column(TypeName = "decimal(5, 2)")]
		public decimal? VitesseVentKmh { get; set; }

		// Relation de navigation : 
		public Station Station { get; set; } // Un Relevé appartient à une Station
	}
}