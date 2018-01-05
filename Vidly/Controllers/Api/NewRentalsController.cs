using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;
namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        // POST /api/newRentals/
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers.ToList().Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.ToList().Where(m => newRental.MoviesId.Contains(m.Id));
            foreach (Movie movie in movies)
            {
                if (movie.Availability == 0)
                    return BadRequest("movie is not available.");

                Rental rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now

                };
                _context.Rentals.Add(rental);
                movie.Availability--;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
