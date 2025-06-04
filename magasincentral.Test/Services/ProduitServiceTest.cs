using Xunit;
using magasincentral.Models;
using magasincentral.Services;
using magasincentral.Test.TestUtils;
using System.Linq;

namespace magasincentral.Test.Services;

/// <summary>
/// Tests unitaires pour le service ProduitService.
/// </summary>
public class ProduitServiceTests
{
    [Fact]
    public void ObtenirTousLesProduits_ShouldReturnProduits()
    {
        // Arrange
        var context = DbContextFactory.Create(nameof(ObtenirTousLesProduits_WhenCalled_ShouldReturnAllProduits));
        context.Produits.AddRange(
            new Produit { Nom = "Crayon", Prix = 1.2m, Categorie = "Papeterie", QuantiteStock = 10 },
            new Produit { Nom = "Stylo", Prix = 2.5m, Categorie = "Papeterie", QuantiteStock = 15 }
        );
        context.SaveChanges();

        var service = new ProduitService(context);

        // Act
        var result = service.ObtenirTousLesProduits();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Reapprovisionner_WithProductIdAndQuantity_ShouldIncreaseStock()
    {
        // Arrange
        var context = DbContextFactory.Create(nameof(Reapprovisionner_WithValidProduit_ShouldIncreaseStock));
        var produit = new Produit
        {
            Nom = "Carnet",
            Categorie = "Papeterie",
            Prix = 2.0m,
            QuantiteStock = 5
        };
        context.Produits.Add(produit);
        context.SaveChanges();

        var service = new ProduitService(context);

        // Act
        service.Reapprovisionner(produit.Id, 10);

        // Assert
        var updated = context.Produits.Find(produit.Id);
        Assert.Equal(15, updated!.QuantiteStock);
    }

    [Fact]
    public void Reapprovisionner_WithInvalidProduit_ShouldDoNothing()
    {
        // Arrange
        var context = DbContextFactory.Create(nameof(Reapprovisionner_WithInvalidProduit_ShouldDoNothing));
        var service = new ProduitService(context);

        // Act
        service.Reapprovisionner(999, 10);

        // Assert
        Assert.Empty(context.Produits);
    }
}
