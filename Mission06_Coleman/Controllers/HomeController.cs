using Microsoft.AspNetCore.Mvc;
using Mission06_Coleman.Models;
using System.Diagnostics;

namespace Mission06_Coleman.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context; // again, so it is seen throughout the whole class
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(Movie response)
        {
            _context.CinemaSlay.Add(response); 
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
