using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.APIs
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            var movies = moviesQuery.ToList().Select(m => Mapper.Map<Movie, MovieDto>(m));
            return Ok(movies);
        }

        // GET  api/movies/1
        [HttpGet]
        [Authorize(Roles = "CanManageMovies")]
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/movies
        [HttpPost]
        [Authorize(Roles = "CanManageMovies")]
        public IHttpActionResult CreateMovie(MovieDto movie_dto)
        {
            if (movie_dto == null)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movie_dto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri.ToString() + '/' + movie.Id), movie_dto);
        }

        // PUT  api/movies/1
        [HttpPut]
        [Authorize(Roles = "CanManageMovies")]
        public IHttpActionResult UpdateMovie(MovieDto movie_dto, int Id)
        {
            if (movie_dto == null)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            Mapper.Map<MovieDto, Movie>(movie_dto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE api/movies/1   
        [HttpDelete]
        [Authorize(Roles = "CanManageMovies")]

        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieIdDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieIdDb == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movieIdDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
