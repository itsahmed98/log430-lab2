using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur pour la gestion des stocks de produits dans les magasins.
/// </summary>
public class StockMagasinController : Controller
{
    private readonly MagasinContext _context;

    public StockMagasinController(MagasinContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var stocks = _context.StocksProduitsMagasins
            .Include(s => s.Produit)
            .Include(s => s.Magasin)
            .ToList();

        return View(stocks);
    }

    [HttpPost]
    public IActionResult Reapprovisionner(int produitId, int magasinId)
    {
        var stock = _context.StocksProduitsMagasins
            .FirstOrDefault(s => s.ProduitId == produitId && s.MagasinId == magasinId);

        if (stock != null)
        {
            stock.Quantite += 20;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}
