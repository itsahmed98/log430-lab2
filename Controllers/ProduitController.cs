using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MagasinMVC.Models;

namespace MagasinMVC.Controllers;

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
}