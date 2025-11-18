using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteoApi.Models
{
	// La classe Station correspond à la table Stations
	public class Station
	{
		// Clé primaire
		public int IdStation { get; set; }

		// Clé étrangère (FK) vers la table Villes
		public int IdVille { get; set; }

		// Colonnes de la table
		public string NomStation { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }

		// Relation de navigation : 
		public Ville Ville { get; set; } // Une Station appartient à une Ville
		public ICollection<ReleveMeteo> RelevesMeteo { get; set; } // Une Station a plusieurs Relevés
	}
}