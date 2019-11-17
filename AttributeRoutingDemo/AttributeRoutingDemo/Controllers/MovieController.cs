using AttributeRoutingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttributeRoutingDemo.Controllers
{

    public class MovieController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        [HttpGet]
        [Route("Movies")]
        [Route("")]
        public ActionResult GetAllMovies()
        {
            return View(db.Movies);
        }

        [HttpGet]
        [Route("Movies/{movieId}")]
        public ActionResult GetMoviebyId(int? movieID)
        {
            if (movieID is null)
            {
                return View("GetAllMovies");
            }
            return View(db.Movies.First(m => m.MovieID == movieID));
        }

        [HttpGet]
        [Route("Actors")]
        public ActionResult GetAllActors()
        {
            return View(db.Actors);
        }

        [HttpGet]
        [Route("Actors/{actorID}")]
        public ActionResult GetActorById(int? actorID)
        {
            if (actorID is null)
            {
                return View("GetAllActors");
            }
            return View(db.Actors.First(a => a.ActorID == actorID));
        }




        //check
        [HttpGet]
        [Route("Actors/{actorID}/Movies")]
        public ActionResult GetActorMovies(int actorID)
        {
            var selectedActor = db.Actors.First(a => a.ActorID == actorID);
            ViewBag.SelectedActorName = selectedActor.FirstName + " " + selectedActor.LastName;
            return View(selectedActor.Movies.ToList());
        }


        [HttpGet]
        [Route("Movie/{movieID}/Actors")]
        public ActionResult GetMovieActors(int movieID)
        {
            var selectedMovie = db.Movies.First(m => m.MovieID == movieID);
            ViewBag.SelectedMovieTitle = selectedMovie.MovieTitle;
            return View(selectedMovie.Actors.ToList());
        }
    }
}