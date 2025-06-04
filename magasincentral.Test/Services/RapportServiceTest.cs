using Xunit;
using magasincentral.Models;
using magasincentral.Services;
using magasincentral.Test.TestUtils;
using System.Collections.Generic;

namespace magasincentral.Test.Services;

/// <summary>
/// Tests unitaires pour le service RapportService.
/// </summary>
public class RapportServiceTests
{
    [Fact]
    public void ObtenirVentesParMagasin_ShouldReturnTotal()
    {
        // Arrange
        var context = DbContextFactory.Create(nameof(ObtenirVentesParMagasin_ShouldReturnTotal));
        var magasin = new Magasin { Id = 1, Nom = "ÉTS", Quartier = "Griffintown" };
        context.Magasins.Add(magasin);
        context.SaveChanges();

        context.Ventes.Add(new Vente { MagasinId = 1, Total = 50 });
        context.Ventes.Add(new Vente { MagasinId = 1, Total = 30 });
        context.SaveChanges();

        var service = new RapportService(context);

        // Act
        var result = service.ObtenirVentesParMagasin();

        // Assert
        Assert.Single(result);
        Assert.Equal(80, result.First().TotalVentes);
    }

    [Fact]
    public void ObtenirProduitsLesPlusVendus_ShouldReturnTopFive()
    {
        // Arrange
        var context = DbContextFactory.Create(nameof(ObtenirProduitsLesPlusVendus_ShouldReturnTopFive));
        var produit = new Produit
        {
            Nom = "Cahier",
            Categorie = "Papeterie",
            Prix = 2.0m,
            QuantiteStock = 5
        };
        context.Produits.Add(produit);
        var vente = new Vente { MagasinId = 1, Total = 0 };
        context.Ventes.Add(vente);
        context.SaveChanges();

        context.LignesVente.Add(new LigneVente
        {
            ProduitId = produit.Id,
            VenteId = vente.Id,
            Quantite = 20,
            PrixUnitaire = 2
        });
        context.SaveChanges();

        var service = new RapportService(context);

        // Act
        var result = service.ObtenirProduitsLesPlusVendus();

        // Assert
        Assert.Single(result);
        Assert.Equal("Cahier", result.First().Produit);
        Assert.Equal(20, result.First().QuantiteVendue);
    }

    [Fact]
    public void ObtenirStockParProduit_ShouldReturnStockList()
    {
        // Arrange
        var context = DbContextFactory.Create(nameof(ObtenirStockParProduit_ShouldReturnStockList));
        context.Produits.Add(new Produit
        {
            Nom = "Marqueur",
            Categorie = "Papeterie",
            Prix = 2.0m,
            QuantiteStock = 5
        });
        context.SaveChanges();

        var service = new RapportService(context);

        // Act
        var result = service.ObtenirStockParProduit();

        // Assert
        Assert.Single(result);
        Assert.Equal("Marqueur", result.First().Produit);
        Assert.Equal(5, result.First().Stock);
    }
}
