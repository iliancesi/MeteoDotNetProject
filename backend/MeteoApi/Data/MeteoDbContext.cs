using Microsoft.EntityFrameworkCore;
using MeteoApi.Models;

namespace MeteoApi.Data
{
    public class MeteoDbContext : DbContext
    {
        public MeteoDbContext(DbContextOptions<MeteoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ville> Villes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<ReleveMeteo> RelevesMeteo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Définition des noms de tables et des clés primaires
            // ToTable("NomTableSQL") est nécessaire car les noms de table SQL sont en PascalCase
            modelBuilder.Entity<Ville>()
                .ToTable("Villes")
                .HasKey(v => v.IdVille);

            modelBuilder.Entity<Station>()
                .ToTable("Stations")
                .HasKey(s => s.IdStation);

            modelBuilder.Entity<ReleveMeteo>()
                .ToTable("RelevesMeteo")
                .HasKey(r => r.IdReleve);

            // 2. Mappage Explicite des Clés Étrangères (Résout les conflits de nommage)

            // Relation Station <-> Ville
            modelBuilder.Entity<Station>()
                .HasOne(s => s.Ville)
                .WithMany(v => v.Stations)
                .HasForeignKey(s => s.IdVille);

            // Relation ReleveMeteo <-> Station
            modelBuilder.Entity<ReleveMeteo>()
                .HasOne(r => r.Station)
                .WithMany(s => s.RelevesMeteo)
                .HasForeignKey(r => r.IdStation);

            base.OnModelCreating(modelBuilder);
        }
    }
}