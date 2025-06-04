using Microsoft.AspNetCore.Mvc;
using magasincentral.Services;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur pour la gestion du stock des produits.
/// Permet de consulter les stocks et de réapprovisionner les produits.
/// </summary>
public class StockController : Controller
{
    private readonly ProduitService _produitService;

    public StockController(ProduitService produitService)
    {
        _produitService = produitService;
    }

    /// <summary>
    /// Affiche la liste des produits et leur stock actuel.
    /// </summary>
    public IActionResult Index()
    {
        var produits = _produitService.ObtenirTousLesProduits();
        return View(produits);
    }

    /// <summary>
    /// Réapprovisionne un produit en ajoutant 20 unités.
    /// </summary>
    [HttpPost]
    public IActionResult Reapprovisionner(int id)
    {
        _produitService.Reapprovisionner(id, 20);
        return RedirectToAction("Index");
    }
}
