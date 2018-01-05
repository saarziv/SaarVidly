using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => (m.Id == id));
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            MoviesFormViewModel ViewModel = new MoviesFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",ViewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var m = _context.Movies.Single(mm => mm.Id == id);
            if (m == null)
                return HttpNotFound();

            MoviesFormViewModel ViewModel = new MoviesFormViewModel(m)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                MoviesFormViewModel ViewModel = new MoviesFormViewModel(Movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", ViewModel);
            }
            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                Movie.Availability = Movie.NumberInStock;
                _context.Movies.Add(Movie);
            }
            else
            {
                var MovieInDB = _context.Movies.Single(m => m.Id == Movie.Id);
                MovieInDB.Name = Movie.Name;
                MovieInDB.ReleaseDate = Movie.ReleaseDate;
                MovieInDB.GenreId = Movie.GenreId;
                MovieInDB.NumberInStock = Movie.NumberInStock;
                Movie.Availability = Movie.NumberInStock;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
        }
        
        /*[Route("movies/released/{year:regex(^\\d{4}$)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }*/
        /*public ActionResult Test(string MovieName,int? id)
        {
            if (string.IsNullOrEmpty(MovieName))
                MovieName = "Lord Of The Rings";
            if (!id.HasValue)
                id = 1;
            Movie M = new Movie() { Name = MovieName ,Id=(int)id };
            return View(M);
        }
        public ActionResult SearchFromMovies()
        {
            return Content("da");
        }*/



    }
}