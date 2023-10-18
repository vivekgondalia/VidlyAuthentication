using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAuthentication.Models;
using VidlyAuthentication.Dtos;

namespace VidlyAuthentication.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/rentals
        public IHttpActionResult GetRentals()
        {
            //Input : What is the Customer Id and return all the rentals?
            //Output : List of all the movies that user has rented
            

            //var moviesDtos = _context.Movies
            //    .Include(m => m.Genre)
            //    .ToList()
            //    .Select(Mapper.Map<Movie, MovieDto>);

            return Ok();
        }

        //GET /api/rentals/1
        public IHttpActionResult GetRental(int id)
        {
            //Input : Indidual rentalId
            //Output : Rented Movie Details

            //var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            //if (movie == null)
            //    return NotFound();

            ////Mapping Objects
            //var movieDto = Mapper.Map<Movie, MovieDto>(movie);
            return Ok();
        }

        //POST /api/rentals
        //[Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto newRental)
        {
            //Edge Case 1
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");
            //Edge Case 2
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Invalid Customer ID");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            //Edge Case 3
            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                //Edge Case 4
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        //PUT /api/rentals/1
        //[Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateRental(int id, MovieDto movieDto)
        {
            //Input : rentalId and movieId

            //if (!ModelState.IsValid)
            //    return BadRequest();

            //var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            //if (movieInDb == null)
            //    return NotFound();

            ////Mapping to an existing object
            //Mapper.Map(movieDto, movieInDb);
            //_context.SaveChanges();

            return Ok();
        }

        //DELETE /api/rentals/1
        //[Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteRental(int id)
        {
            //var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            //if (movieInDb == null)
            //    return NotFound();

            //_context.Movies.Remove(movieInDb);
            //_context.SaveChanges();

            return Ok();
        }

    }
}
