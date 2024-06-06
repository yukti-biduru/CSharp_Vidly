using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.APIs
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddRentals(NewRentalsDto rentals)
        {
            var customer = _context.Customers.Single(c => c.Id == rentals.CustomerId);
            var movies = _context.Movies.Where(m => rentals.MovieIds.Contains(m.Id));
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie: " + movie.Name + " is not available");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Movie = movie,
                    Customer = customer,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
