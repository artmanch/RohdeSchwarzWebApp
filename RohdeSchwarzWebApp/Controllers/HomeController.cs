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

        /// <summary>
        /// Используем POST-запрос, так как сохраняем данные на "сервер" и проверяем целостность токена
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SetAmperage(AmperageViewModel Model)
        {
            if(!ModelState.IsValid)
                return View(nameof(Index), Model);

            _AmperageService.SetAmperage(Model.Amperage);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Рендерим ответ от сервера на основную страницу с помощью частичного представления
        /// </summary>
        /// <returns>частичное представление с информацией о текущей силе тока источника</returns>
        public IActionResult GetAmperage()
        {
            return PartialView("Partial/_AmperagePartial", new AmperageViewModel
            {
                Amperage = _AmperageService.GetAmperage()
            });
        }
    }
}
