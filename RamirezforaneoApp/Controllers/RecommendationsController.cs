using Microsoft.AspNetCore.Mvc;
using RamirezforaneoApp.AccesPoint;

namespace RamirezforaneoApp.Controllers
{
    public class RecommendationsController : Controller
    {
        private readonly GoogleAccesPoint _accesPoint;

        public RecommendationsController(GoogleAccesPoint accesPoint)
        {
            _accesPoint = accesPoint;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction(nameof(Index));
            }

            var location = "@-0.16235095277405412,-78.45915383165817,15.1z"; //Udla Park location
            var places = _accesPoint.SearchPlaces(query, location);
            var topPlaces = places.Take(8).ToList();

            return View("Index", topPlaces ); 
        }
    }
}
