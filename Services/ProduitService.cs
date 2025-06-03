using MagasinMVC.Models;

namespace MagasinMVC.Services;

/// <summary>
/// Service pour gérer les opérations liées aux produits dans le système de gestion de magasin.
/// </summary>
public class ProduitService
{
    /// <summary>
    /// Contexte de la base de données pour accéder aux données des produits.
    /// </summary>
    private readonly MagasinContext _context;

    /// <summary>
    /// Constructeur du service ProduitService.
    /// </summary>
    /// <param name="context">Contexte de la base de données</param>
    public ProduitService(MagasinContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtenir tous les produits disponibles dans le magasin.
    /// </summary>
    /// <returns>Une liste des produits</returns>
    public List<Produit> ObtenirTousLesProduits()
    {
        return _context.Produits.ToList();
    }


    public void Reapprovisionner(int idProduit, int quantite)
    {
        var produit = _context.Produits.FirstOrDefault(p => p.Id == idProduit);
        if (produit != null)
        {
            produit.QuantiteStock += quantite;
            _context.SaveChanges();
        }
    }
}
