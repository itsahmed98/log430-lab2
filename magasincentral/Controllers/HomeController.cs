using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using magasincentral.Models;

namespace magasincentral.Controllers;

/// <summary>
/// Contrôleur principal de l'application.
/// Gère la page d'accueil, la politique de confidentialité et les erreurs.
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Affiche la page d'accueil.
    /// </summary>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Affiche la politique de confidentialité.
    /// </summary>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Affiche la page d'erreur avec l'ID de la requête.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

