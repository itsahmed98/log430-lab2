using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using magasincentral.Data;

namespace magasincentral.Data;

/// <summary>
/// Fournit une factory pour que les outils en ligne de commande EF Core
/// puissent instancier MagasinContext (ex: pour les migrations).
/// </summary>
public class MagasinContextFactory : IDesignTimeDbContextFactory<MagasinContext>
{
    public MagasinContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MagasinContext>();

        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=magasin");

        return new MagasinContext(optionsBuilder.Options);
    }
}
