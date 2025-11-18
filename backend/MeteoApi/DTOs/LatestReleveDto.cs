namespace MeteoApi.DTOs
{
    public class LatestReleveDto
    {
        // Données du Relevé
        public int IdReleve { get; set; }
        public DateTime Horodatage { get; set; }
        public decimal TemperatureCelsius { get; set; }
        public decimal? HumiditePourcentage { get; set; }
        public decimal? VitesseVentKmh { get; set; }

        // Données de la Station
        public int IdStation { get; set; }
        public string NomStation { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        // Données de la Ville
        public int IdVille { get; set; }
        public string NomVille { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
    }
}