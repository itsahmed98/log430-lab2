using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using magasincentral.Models;
using magasincentral.Services;
using magasincentral.Models.ViewModels;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur pour la génération du rapport consolidé.
/// Affiche les ventes par magasin, les produits les plus vendus et le stock actuel.
/// </summary>
public class RapportController : Controller
{
    private readonly RapportService _rapportService;

    public RapportController(RapportService rapportService)
    {
        _rapportService = rapportService;
    }

    /// <summary>
    /// Affiche la vue du rapport consolidé.
    /// </summary>
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