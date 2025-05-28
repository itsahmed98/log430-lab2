using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MagasinMVC.Models;

namespace MagasinMVC.Controllers;

public class ProduitController : Controller
{
    private readonly ILogger<ProduitController> _logger;

    public ProduitController(ILogger<ProduitController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
