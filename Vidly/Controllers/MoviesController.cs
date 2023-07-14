using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var viewModel = _context.Movies.Include(m => m.Genre).ToList();
            return View(viewModel);
        }

        public ActionResult Details(int id)
        { 
            var viewModel = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Save(Movie movie) 
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m =>  m.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return HttpNotFound();  
            }
            else
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
        }
    }
}