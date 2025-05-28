using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MagasinMVC.Controllers;

public class ProduitController : Controller
{
    private readonly MagasinContext _context;
    private readonly ILogger<ProduitController> _logger;

    public ProduitController(ILogger<ProduitController> logger, MagasinContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateProduct()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateProduct(Produit produit)
    {
        if (ModelState.IsValid)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(produit);
    }
}
