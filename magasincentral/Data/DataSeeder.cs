using magasincentral.Models;

namespace magasincentral.Data;

/// <summary>
/// Remplir la BD
/// <summary>
public static class DataSeeder
{
    public static void Seed(MagasinContext context)
    {
        if (context.Produits.Any() || context.Magasins.Any()) return;

        // Magasins
        var magasin1 = new Magasin { Nom = "ÉTS", Quartier = "Griffintown" };
        var magasin2 = new Magasin { Nom = "Magasin Centre-Ville", Quartier = "Downtown" };

        context.Magasins.AddRange(magasin1, magasin2);

        // Produits
        var produit1 = new Produit { Nom = "Crayon", Categorie = "Papeterie", Prix = 1.50m, QuantiteStock = 100, Description = "Crayon HB" };
        var produit2 = new Produit { Nom = "Stylo", Categorie = "Papeterie", Prix = 3.00m, QuantiteStock = 50, Description = "Stylo bleu à bille" };
        var produit3 = new Produit { Nom = "Cahier", Categorie = "Papeterie", Prix = 5.00m, QuantiteStock = 30, Description = "Cahier lignés" };

        context.Produits.AddRange(produit1, produit2, produit3);

        // Enregistrer en base
        context.SaveChanges();
    }
}
