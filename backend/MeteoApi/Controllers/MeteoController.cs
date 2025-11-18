using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeteoApi.Data;
using MeteoApi.DTOs; // IMPORTANT: Ajouter cette directive

namespace MeteoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeteoController : ControllerBase
    {
        private readonly MeteoDbContext _context;

        public MeteoController(MeteoDbContext context)
        {
            _context = context;
        }

        // Endpoint: GET /api/Meteo/temps-reel
        // Le type de retour est maintenant IEnumerable<LatestReleveDto>
        [HttpGet("temps-reel")]
        public async Task<ActionResult<IEnumerable<LatestReleveDto>>> GetLatestReleves()
        {
            // 1. Trouver l'ID du relevé le plus récent pour chaque station.
            var latestReleveIds = await _context.RelevesMeteo
                .GroupBy(r => r.IdStation)
                .Select(g => g.OrderByDescending(r => r.Horodatage).First().IdReleve)
                .ToListAsync();

            // 2. Récupérer les relevés complets et projeter DANS le DTO
            var latestRelevesDto = await _context.RelevesMeteo
                .Where(r => latestReleveIds.Contains(r.IdReleve))
                .Include(r => r.Station)
                .ThenInclude(s => s.Ville)
                .Select(r => new LatestReleveDto // <<--- Projection vers le DTO
                {
                    // Mappage du Relevé
                    IdReleve = r.IdReleve,
                    Horodatage = r.Horodatage,
                    TemperatureCelsius = r.TemperatureCelsius,
                    HumiditePourcentage = r.HumiditePourcentage,
                    VitesseVentKmh = r.VitesseVentKmh,

                    // Mappage de la Station
                    IdStation = r.IdStation,
                    NomStation = r.Station.NomStation,
                    Latitude = r.Station.Latitude,
                    Longitude = r.Station.Longitude,

                    // Mappage de la Ville
                    IdVille = r.Station.Ville.IdVille,
                    NomVille = r.Station.Ville.NomVille,
                    CodePostal = r.Station.Ville.CodePostal
                })
                .OrderBy(dto => dto.NomVille)
                .ToListAsync();

            return latestRelevesDto;
        }
    }
}