using Microsoft.AspNetCore.Mvc;
using MagasinMVC.Services;

namespace MagasinMVC.Controllers
{
    public class StockController : Controller
    {
        private readonly ProduitService _produitService;

        public StockController(ProduitService produitService)
        {
            _produitService = produitService;
        }

        public IActionResult Index()
        {
            var produits = _produitService.ObtenirTousLesProduits();
            return View(produits);
        }

        [HttpPost]
        public IActionResult Reapprovisionner(int id)
        {
            _produitService.Reapprovisionner(id, 20);
            return RedirectToAction("Index");
        }
    }
}
