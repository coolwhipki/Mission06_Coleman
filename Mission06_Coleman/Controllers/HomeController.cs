using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Coleman.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            ViewBag.Ratings = _context.Movies
                .Select(m => m.Rating)
                .Distinct()
                .ToList();

            return View("NewMovie", new Movie());
        }

        [HttpPost]
        public IActionResult NewMovie(Movie response)
        {

            if (ModelState.IsValid)
            {   
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                ViewBag.Ratings = _context.Movies
                    .Select(m => m.Rating)
                    .Distinct()
                    .ToList();

                return View(response);
            }
        }

        public IActionResult MovieData()
        {
            var movies = _context.Movies
                .Include("Category")
                .ToList();
            return View(movies);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
            .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            ViewBag.Ratings = _context.Movies
                .Select(m => m.Rating)
                .Distinct()
                .ToList();

            return View("NewMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieData");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie app)
        {
            _context.Movies.Remove(app);
            _context.SaveChanges();
            return RedirectToAction("Waitlist");
        }
    }
}
