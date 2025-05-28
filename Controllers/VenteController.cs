using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MagasinMVC.Models;
using MagasinMVC.Models.ViewModels;

namespace MagasinMVC.Controllers;

public class VenteController : Controller
{
    private readonly MagasinContext _context;

    public VenteController(MagasinContext context)
    {
        _context = context;
    }

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

    [HttpPost]
    public IActionResult Create(CreerVenteViewModel model)
    {
        var produit = _context.Produits.FirstOrDefault(p => p.Id == model.ProduitId);
        if (produit == null) return RedirectToAction("Create");

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
                    Quantite = model.Quantite
                }
            }
        };

        _context.Ventes.Add(vente);
        _context.SaveChanges();

        return RedirectToAction("Index", "Performance");
    }
}
