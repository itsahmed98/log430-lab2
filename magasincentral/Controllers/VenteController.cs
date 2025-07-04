using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using magasincentral.Models;
using magasincentral.Models.ViewModels;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur pour la gestion des ventes.
/// Permet de créer une vente liée à un produit et un magasin.
/// </summary>
public class VenteController : Controller
{
    private readonly MagasinContext _context;

    public VenteController(MagasinContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Affiche le formulaire de création d'une vente.
    /// </summary>
    public IActionResult Create()
    {
        var model = new CreerVenteViewModel
        {
            ListeMagasins = _context.Magasins.Select(m =>
                new SelectListItem { Value = m.Id.ToString(), Text = m.Nom }).ToList(),

            ListeProduits = _context.Produits.Select(p =>
                new SelectListItem { Value = p.Id.ToString(), Text = p.Nom }).ToList()
        };

        return View(model);
    }

    /// <summary>
    /// Traite la soumission du formulaire de vente.
    /// </summary>
    [HttpPost]
    public IActionResult Create(CreerVenteViewModel model)
    {
        var produit = _context.Produits.FirstOrDefault(p => p.Id == model.ProduitId);
        if (produit == null) return RedirectToAction("Create");

        // Vérifie que le stock local est suffisant
        var stockMagasin = _context.StocksProduitsMagasins
            .FirstOrDefault(s => s.ProduitId == model.ProduitId && s.MagasinId == model.MagasinId);

        if (stockMagasin == null || stockMagasin.Quantite < model.Quantite)
        {
            TempData["Erreur"] = "Stock insuffisant dans le magasin.";
            return RedirectToAction("Create");
        }

        // Calcul du montant
        var montant = produit.Prix * model.Quantite;

        var vente = new Vente
        {
            DateVente = DateTime.Now,
            Total = montant,
            MagasinId = model.MagasinId,
            Lignes = new List<LigneVente>
            {
                new LigneVente
                {
                    ProduitId = produit.Id,
                    Quantite = model.Quantite,
                    PrixUnitaire = produit.Prix
                }
            }
        };

        // Met à jour le stock
        stockMagasin.Quantite -= model.Quantite;

        _context.Ventes.Add(vente);
        _context.SaveChanges();

        return RedirectToAction("Index", "Performance");
    }

}