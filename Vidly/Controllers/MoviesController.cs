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
    }
}