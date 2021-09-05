using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RohdeSchwarzWebApp.Models;
using RohdeSchwarzWebApp.Services.Interfaces;

namespace RohdeSchwarzWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAmperageService _AmperageService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IAmperageService AmperageService, ILogger<HomeController> logger)
        {
            _AmperageService = AmperageService;
            _logger = logger;
        }

        public IActionResult Index() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SetAmperage(AmperageViewModel Model)
        {
            if(!ModelState.IsValid)
                return View(nameof(Index), Model);

            _AmperageService.SetAmperage(Model.Amperage);
            return RedirectToAction("Index");
        }

        public IActionResult GetAmperage()
        {
            return PartialView("Partial/_AmperagePartial", new AmperageViewModel
            {
                Amperage = _AmperageService.GetAmperage()
            });
        }
    }
}
