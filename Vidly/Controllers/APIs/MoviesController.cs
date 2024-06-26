﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Migrations;
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
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(m => Mapper.Map<Movie, MovieDto>(m)));
        }

        // GET  api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int Id)
        {
            var movie  = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movie_dto)
        {
            if(movie_dto == null)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto,Movie>(movie_dto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri.ToString()+'/'+movie.Id), movie_dto);
        }

        // PUT  api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movie_dto, int Id)
        {
            if(movie_dto == null)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if(movieInDb == null)
            {
                return NotFound();
            }
            Mapper.Map<MovieDto, Movie>(movie_dto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE api/movies/1   
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
