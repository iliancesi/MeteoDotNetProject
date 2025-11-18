using MeteoApi.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// --- Configuration de la BDD ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MeteoDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);

// --- Services de l'API et Résolution du Cycle JSON ---
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Résout l'erreur de cycle JSON
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorPages();

// ATTENTION: AUCUN SERVICE SWAGGER/OPENAPI ICI

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // AUCUN MIDDLEWARE SWAGGER/OPENAPI ICI
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers(); // ROUTAGE DE L'API

app.Run();