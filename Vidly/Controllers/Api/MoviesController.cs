using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;
namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var moviesDtos = _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            return Ok(moviesDtos);
        }
        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList().SingleOrDefault(m => m.Id == id);
            if(movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto mDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            mDto.Availability = mDto.NumberInStock;
            var movie = Mapper.Map<MovieDto, Movie>(mDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            mDto.Id = movie.Id;
            return Created(Request.RequestUri + "/" + movie.Id, mDto);
        }
        //PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id,MovieDto mDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movieInDb == null)
                NotFound();
            
            Mapper.Map(mDto, movieInDb);

            _context.SaveChanges();
            return Ok();
            
        }
        //DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.ToList().SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}

