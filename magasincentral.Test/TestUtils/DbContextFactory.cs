using Microsoft.EntityFrameworkCore;

namespace magasincentral.Test.TestUtils;

/// <summary>
/// Fournit un contexte en mémoire pour les tests.
/// </summary>
public static class DbContextFactory
{
    /// <summary>
    /// Crée un nouveau contexte de test avec une base en mémoire nommée.
    /// </summary>
    /// <param name="dbName">Nom de la base (habituellement le nom du test)</param>
    public static MagasinContext Create(string dbName)
    {
        var options = new DbContextOptionsBuilder<MagasinContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new MagasinContext(options);
    }
}
