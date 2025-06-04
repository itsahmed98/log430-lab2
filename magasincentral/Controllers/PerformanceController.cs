using Microsoft.AspNetCore.Mvc;
using magasincentral.Services;
using magasincentral.Models.ViewModels;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur pour le tableau de bord des performances des magasins.
/// Affiche les indicateurs de vente par magasin.
/// </summary>
public class PerformanceController : Controller
{
    private readonly RapportService _rapportService;

    public PerformanceController(RapportService rapportService)
    {
        _rapportService = rapportService;
    }

    /// <summary>
    /// Affiche la vue des performances des magasins.
    /// </summary>
    public IActionResult Index()
    {
        var performances = _rapportService.ObtenirPerformancesMagasins();
        return View(performances);
    }
}