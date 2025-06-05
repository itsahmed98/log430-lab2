using Microsoft.AspNetCore.Mvc;
using magasincentral.Models;
using Microsoft.EntityFrameworkCore;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur responsable de la gestion des magasins.
/// Permet de lister, créer et afficher les magasins disponibles.
/// </summary>
public class MagasinController : Controller
{
    private readonly MagasinContext _context;

    /// <summary>
    /// Constructeur avec injection du contexte de base de données.
    /// </summary>
    public MagasinController(MagasinContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Affiche la liste complète des magasins existants.
    /// </summary>
    public IActionResult Index()
    {
        var magasins = _context.Magasins.ToList();
        return View(magasins);
    }

    /// <summary>
    /// Affiche le formulaire de création d'un nouveau magasin.
    /// </summary>
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Traite la création d'un nouveau magasin après soumission du formulaire.
    /// </summary>
    /// <param name="magasin">Magasin à ajouter.</param>
    [HttpPost]
    public IActionResult Create(Magasin magasin)
    {
        if (ModelState.IsValid)
        {
            _context.Magasins.Add(magasin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(magasin);
    }

    /// <summary>
    /// Affiche les détails d'un magasin spécifique, y compris ses stocks de produits.
    /// </summary>
    public IActionResult Details(int id)
    {
        var magasin = _context.Magasins
            .Include(m => m.Stocks)
            .ThenInclude(s => s.Produit)
            .FirstOrDefault(m => m.Id == id);

        if (magasin == null)
            return NotFound();

        return View(magasin);
    }
}
