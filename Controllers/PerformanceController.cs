using Microsoft.AspNetCore.Mvc;
using MagasinMVC.Services;
using MagasinMVC.Models.ViewModels;

namespace MagasinMVC.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly RapportService _rapportService;

        public PerformanceController(RapportService rapportService)
        {
            _rapportService = rapportService;
        }

        public IActionResult Index()
        {
            var performances = _rapportService.ObtenirPerformancesMagasins();
            return View(performances);
        }
    }
}
