using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MagasinMVC.Models;
using MagasinMVC.Services;
using MagasinMVC.Models.ViewModels;

namespace MagasinMVC.Controllers;

public class RapportController : Controller
{
    private readonly RapportService _rapportService;

    public RapportController(RapportService rapportService)
    {
        _rapportService = rapportService;
    }

    public IActionResult Index()
    {
        var ventes = _rapportService.ObtenirVentesParMagasin();
        var topProduits = _rapportService.ObtenirProduitsLesPlusVendus();
        var stocks = _rapportService.ObtenirStockParProduit();

        var viewModel = new RapportViewModel
        {
            VentesParMagasin = ventes,
            ProduitsLesPlusVendus = topProduits,
            Stocks = stocks
        };

        return View(viewModel);
    }
}
