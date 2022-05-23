using Microsoft.AspNetCore.Mvc;
using OFood.Data.Services;
using OFood.Models;
using System.Diagnostics;

namespace OFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRestaurantData _db;

        public HomeController(ILogger<HomeController> logger, IRestaurantData db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            //var model = _db.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}