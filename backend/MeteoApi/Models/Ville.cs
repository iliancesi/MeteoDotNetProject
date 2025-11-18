using System.Collections.Generic;

namespace MeteoApi.Models
{
    // La classe Ville correspond à la table Villes
    public class Ville
    {
        // Clé primaire (IdVille)
        public int IdVille { get; set; }

        // Colonnes de la table
        public string NomVille { get; set; }
        public string CodePostal { get; set; }

        // Relation de navigation (pour EF Core) : Une Ville a plusieurs Stations
        public ICollection<Station> Stations { get; set; }
    }
}