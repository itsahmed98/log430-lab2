using Xunit;
using magasincentral.Controllers;
using magasincentral.Data;
using magasincentral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace magasincentral.Test.Controllers;

/// <summary>
/// Tests unitaires pour la mise à jour d’un produit.
/// </summary>
public class ProduitControllerTests
{
    private MagasinContext GetDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<MagasinContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new MagasinContext(options);
    }

    /// <summary>
    /// Vérifie que le produit est bien modifié lorsque les données sont valides.
    /// </summary>
    [Fact]
    public void Edit_WithValidProduit_ShouldUpdateProduit()
    {
        // Arrange
        var context = GetDbContext(nameof(Edit_WithValidProduit_ShouldUpdateProduit));
        var produit = new Produit
        {
            Nom = "Stylo",
            Categorie = "Papeterie",
            Prix = 1.5m,
            QuantiteStock = 100,
            Description = "Ancienne description"
        };
        context.Produits.Add(produit);
        context.SaveChanges();

        var controller = new ProduitController(null!, context);

        var updated = new Produit
        {
            Id = produit.Id,
            Nom = "Stylo Bille",
            Categorie = "Papeterie",
            Prix = 2.0m,
            Description = "Nouvelle description"
        };

        // Act
        var result = controller.Edit(updated);

        // Assert
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Stock", redirect.ControllerName);
        Assert.Equal("Index", redirect.ActionName);

        var produitModifie = context.Produits.Find(produit.Id);
        Assert.Equal("Stylo Bille", produitModifie!.Nom);
        Assert.Equal("Nouvelle description", produitModifie.Description);
        Assert.Equal(2.0m, produitModifie.Prix);
    }

    /// <summary>
    /// Vérifie qu’une tentative de modification avec un produit inexistant retourne 404.
    /// </summary>
    [Fact]
    public void Edit_WithUnknownProduitId_ShouldReturnNotFound()
    {
        // Arrange
        var context = GetDbContext(nameof(Edit_WithUnknownProduitId_ShouldReturnNotFound));
        var controller = new ProduitController(null!, context);

        var fakeProduit = new Produit
        {
            Id = 999,
            Nom = "Inexistant",
            Categorie = "Invalide",
            Prix = 10,
            Description = "N/A"
        };

        // Act
        var result = controller.Edit(fakeProduit);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    /// <summary>
    /// Vérifie que lorsqu’un modèle invalide est soumis, on retourne la vue avec le même modèle.
    /// </summary>
    [Fact]
    public void Edit_WithInvalidModelState_ShouldReturnViewWithModel()
    {
        // Arrange
        var context = GetDbContext(nameof(Edit_WithInvalidModelState_ShouldReturnViewWithModel));
        var produit = new Produit
        {
            Id = 1,
            Nom = "",
            Prix = -5,
            Description = ""
        };

        var controller = new ProduitController(null!, context);
        controller.ModelState.AddModelError("Nom", "Champ requis");

        // Act
        var result = controller.Edit(produit);

        // Assert
        var view = Assert.IsType<ViewResult>(result);
        Assert.Same(produit, view.Model);
    }
}
