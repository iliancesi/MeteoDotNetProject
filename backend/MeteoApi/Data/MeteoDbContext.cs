using Microsoft.EntityFrameworkCore;
using MeteoApi.Models;

namespace MeteoApi.Data
{
    public class MeteoDbContext : DbContext
    {
        // Constructeur qui permet la configuration de la connexion
        public MeteoDbContext(DbContextOptions<MeteoDbContext> options)
            : base(options)
        {
        }

        // Chaque DbSet correspond à une table dans la base de données
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<ReleveMeteo> RelevesMeteo { get; set; }

        // Mappage pour assurer que les noms de tables C# correspondent aux noms SQL
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ville>().ToTable("Villes");
            modelBuilder.Entity<Station>().ToTable("Stations");
            modelBuilder.Entity<ReleveMeteo>().ToTable("RelevesMeteo");
        }
    }
}