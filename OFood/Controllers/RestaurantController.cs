 using Microsoft.AspNetCore.Mvc;
using OFood.Data.Models;
using OFood.Data.Services;

namespace OFood.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantData _db;
        public RestaurantController(IRestaurantData db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _db.Get(id);
            if(model == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Restaurant restaurant)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            _db.Add(restaurant);

            //redirect to Details and pass Id of new restaurant
            return RedirectToAction("Details", new { Id = restaurant.Id});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Update(restaurant);
            //Pass a message to the user of successful edit
            TempData["Message"] = "Restaurant Successfully Modified";
            return RedirectToAction("Details", new { Id = restaurant.Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.Get(id);
            if(model == null)
            {
                return View("Not Found");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
