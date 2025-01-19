using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RamirezforaneoApp.Data;
using RamirezforaneoApp.Models;
using System.Diagnostics;

namespace RamirezforaneoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var activeSliders = _context.Slider.Where(s => s.ImageStatus).ToList();
            return View(activeSliders);
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
