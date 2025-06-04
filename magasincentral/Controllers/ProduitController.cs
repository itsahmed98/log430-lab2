using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using magasincentral.Models;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur pour la gestion des produits.
/// Permet la création et la consultation des produits.
/// </summary>
public class ProduitController : Controller
{
    private readonly MagasinContext _context;
    private readonly ILogger<ProduitController> _logger;

    public ProduitController(ILogger<ProduitController> logger, MagasinContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Affiche la page principale des produits.
    /// </summary>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Affiche le formulaire de création de produit.
    /// </summary>
    public IActionResult CreateProduct()
    {
        return View();
    }

    /// <summary>
    /// Traite la soumission du formulaire de création d'un nouveau produit.
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateProduct(Produit produit)
    {
        Console.WriteLine($"Produit reçu : {produit.Nom}");
        if (ModelState.IsValid)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(produit);
    }


    /// <summary>
    /// Retourner la page de modification pour un produit.
    /// </summary>
    public IActionResult Edit(int id)
    {
        var produit = _context.Produits.Find(id);
        if (produit == null)
        {
            return NotFound();
        }
        return View(produit);
    }


    /// <summary>
    /// Traite la soumission du formulaire de modification d'un produit.
    /// </summary>
    [HttpPost]
    public IActionResult Edit(Produit produit)
    {
        if (!ModelState.IsValid)
            return View(produit);

        var produitExistant = _context.Produits.Find(produit.Id);
        if (produitExistant == null)
            return NotFound();

        produitExistant.Nom = produit.Nom;
        produitExistant.Categorie = produit.Categorie;
        produitExistant.Prix = produit.Prix;
        produitExistant.Description = produit.Description;

        _context.SaveChanges();

        return RedirectToAction("Index", "Stock");
    }

}