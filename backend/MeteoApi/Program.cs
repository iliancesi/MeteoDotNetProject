using MeteoApi.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Configuration des Politiques CORS (NOUVEAU) ---
// Ceci permet au navigateur d'accéder à l'API depuis le fichier index.html local
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.AllowAnyOrigin() // Autorise les requêtes de n'importe quelle origine (y compris file://)
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
// ----------------------------------------------------

// 2. Configuration de la BDD
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MeteoDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);

// 3. Services de l'API et Résolution du Cycle JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Gère les références circulaires entre les entités (ex: Ville -> Station -> Ville)
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

// 4. Ajout des services Razor Pages (même si non utilisé pour l'API)
builder.Services.AddRazorPages();

var app = builder.Build();

// 5. Configuration du pipeline
if (app.Environment.IsDevelopment())
{
    // AUCUN MIDDLEWARE SWAGGER/OPENAPI ici (pour éviter les erreurs CS1061)
}

app.UseHttpsRedirection();

// --- 6. Utilisation de la politique CORS (CRUCIAL pour le HTML) ---
app.UseCors("AllowFrontend");
// ----------------------------------------------------

app.UseStaticFiles();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();