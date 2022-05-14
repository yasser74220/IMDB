using IMDB.DataLayer;
using IMDB.Models;
using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IMDB.Controllers
{
    public class AdminController : Controller
    {
        private IMDBContext db = new IMDBContext();

        public ActionResult Index()
        {
            List<Movie> movies = db.Movies.ToList();
            return View(movies);
        }


        [HttpGet]
        public ActionResult CreateMovie()
        {
            var directors = db.Directors.ToList();
            var actors = db.Actors.ToList();
            var MovieActorsDirectors = new MovieActorsDirectors
            {
                Directors = directors,
                Actors = actors
            };
            return View(MovieActorsDirectors);
        }

        [HttpPost]
        public ActionResult CreateMovie(MovieActorsDirectors movieActorsDirectors, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic);

                    file.SaveAs(path);

                    movieActorsDirectors.Movie.ImgPath = pic;
                }
                if(movieActorsDirectors.ActorsIds != null)
                {
                    foreach(var id in movieActorsDirectors.ActorsIds)
                    {
                        db.MovieActors.Add(new MovieActor
                        {
                            Actor_ID = id,
                            Movie_ID = movieActorsDirectors.Movie.Movie_ID
                        });
                    }
                }

                db.Movies.Add(movieActorsDirectors.Movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteMovie(int id)
        {
            DeleteMovieAux(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditMovie(int id)
        {
            var directors = db.Directors.ToList();
            var actors = db.Actors.ToList();
            List<MovieActor> movieActors = db.MovieActors.Where(x => x.Movie_ID == id).ToList();
            var MovieActorsDirectors = new MovieActorsDirectors
            {
                Directors = directors,
                Actors = actors,
                Movie = db.Movies.Single(x => x.Movie_ID == id),
                MovieActors = movieActors
            };
            return View(MovieActorsDirectors);
        }

        [HttpPost]
        public ActionResult EditMovie(MovieActorsDirectors movieActorsDirectors, HttpPostedFileBase file, int id)
        {
            if (ModelState.IsValid)
            {
                /* This Method acually removes the record of the movie being edited
                 * and inserts a new record containing the new edited information
                 */
                
                //Remove the edited movie
                DeleteMovieAux(id);
               
                //Add the new movie
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic);

                    file.SaveAs(path);

                    movieActorsDirectors.Movie.ImgPath = pic;
                }
                movieActorsDirectors.Movie.Movie_ID = id;
                db.Movies.Add(movieActorsDirectors.Movie);
                foreach (var actorId in movieActorsDirectors.ActorsIds)
                {
                    db.MovieActors.Add(new MovieActor
                    {
                        Actor_ID = actorId,
                        Movie_ID = movieActorsDirectors.Movie.Movie_ID
                    });
                }
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            return View();
        }

        private void DeleteMovieAux(int id)
        {
            var movie = db.Movies.FirstOrDefault(x => x.Movie_ID == id);
            List<MovieActor> movieActors = db.MovieActors.Where(x => x.Movie_ID == id).ToList();
            if (movie != null)
            {
                //should remove all dependent records in other tables before removing the movie
                foreach (var movieActor in movieActors)
                {
                    db.MovieActors.Remove(movieActor);
                }
                db.Movies.Remove(movie);
                db.SaveChanges();

            }
        }

        public ActionResult MovieDetails(int id)
        {
            List<MovieActor> movieActors = db.MovieActors.Where(x => x.Movie_ID == id).ToList();
            MovieActors_vm movieActors_vm = new MovieActors_vm
            {
                Movie = db.Movies.Single(x => x.Movie_ID == id),
                MovieActors = movieActors
            };
            return View(movieActors_vm);
        }

        /*Actor Profile*/

        public ActionResult Actors()
        {
            List<Actor> actors = db.Actors.ToList();
            return View(actors);
        }

        public ActionResult ActorProfile(int id)
        {
            List<MovieActor> movieActors = db.MovieActors.Where(x => x.Actor_ID == id).ToList();
            ActorMovies actorMovies = new ActorMovies
            {
                MovieActors = movieActors,
                Actor = db.Actors.Single(x => x.Actor_ID == id)
            };
            return View(actorMovies);
        }

        [HttpGet]
        public ActionResult CreateActor()
        {
            var movies = db.Movies.ToList();
            var actorMovies = new ActorMovies
            {
                Movies = movies
            };
            return View(actorMovies);
        }

        [HttpPost]
        public ActionResult CreateActor(ActorMovies actorMovies, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                List<Actor> oldActors = db.Actors.ToList();
                bool duplicate = false;
                foreach(var actor in oldActors)
                {
                    if(actorMovies.Actor.FirstName == actor.FirstName &&
                       actorMovies.Actor.LastName == actor.LastName &&
                       actorMovies.Actor.Age == actor.Age)
                    {
                        duplicate = true;
                        break;
                    }
                }

                if(duplicate)
                    return RedirectToAction("Actors");

                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic);

                    file.SaveAs(path);

                    actorMovies.Actor.ImgPath = pic;
                }

                if(actorMovies.MoviesIds != null)
                {
                    foreach (var id in actorMovies.MoviesIds)
                    {
                        db.MovieActors.Add(new MovieActor
                        {
                            Actor_ID = actorMovies.Actor.Actor_ID,
                            Movie_ID = id
                        });
                    }
                }

                db.Actors.Add(actorMovies.Actor);
                db.SaveChanges();
                return RedirectToAction("Actors");
            }
            return View();
        }

        public ActionResult DeleteActor(int id)
        {
            var actor = db.Actors.FirstOrDefault(x => x.Actor_ID == id);
            List<MovieActor> movieActors = db.MovieActors.Where(x => x.Actor_ID == id).ToList();
            if (actor != null)
            {
                //should remove all dependent records in other tables before removing the movie
                foreach (var movieActor in movieActors)
                {
                    db.MovieActors.Remove(movieActor);
                }
                db.Actors.Remove(actor);
                db.SaveChanges();

            }
            return RedirectToAction("Actors");
        }

        [HttpGet]
        public ActionResult EditActor(int id)
        {
            List<MovieActor> movieActors = db.MovieActors.Where(x => x.Actor_ID == id).ToList();
            
            List<Movie> movies = new List<Movie>();
            foreach(var movieActor in movieActors)
            {
                movies.Add(db.Movies.Single(x => x.Movie_ID == movieActor.Movie_ID));
            }
            
            ActorMovies actorMovies = new ActorMovies
            {
                Movies = movies,
                MovieActors = movieActors,
                Actor = db.Actors.Single(x => x.Actor_ID == id)
            };
            return View(actorMovies);
        }

        [HttpPost]
        public ActionResult EditActor(ActorMovies actorMovies, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic);

                    file.SaveAs(path);

                    actorMovies.Actor.ImgPath = pic;
                }
                
                db.Entry(actorMovies.Actor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ActorProfile", new RouteValueDictionary ( new { Controller="Admin", Action= "ActorProfile", Id = actorMovies.Actor.Actor_ID } ));
                
            }
            catch
            {
                return View();
            }
        }

        /*Director Profile*/

        public ActionResult Directors()
        {
            List<Director> directors = db.Directors.ToList();

            return View(directors);
        }

        public ActionResult DirectorProfile(int id)
        {
            List<Movie> movies = db.Movies.Where(x => x.Director_ID == id).ToList();
            DirectorMovies directorMovies = new DirectorMovies
            {
                Movies = movies,
                Director = db.Directors.Single(x => x.Director_ID == id)
            };
            return View(directorMovies);
        }
        
        [HttpGet]
        public ActionResult CreateDirector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDirector(Director director)
        {
            if (ModelState.IsValid)
            {
                List<Director> oldDirectors = db.Directors.ToList();
                bool duplicate = false;
                foreach (var oldDirector in oldDirectors)
                {
                    if (oldDirector.FirstName == director.FirstName &&
                       oldDirector.LastName == director.LastName &&
                       oldDirector.Age == director.Age)
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (!duplicate)
                {
                    db.Directors.Add(director);
                    db.SaveChanges();
                }

                return RedirectToAction("Directors");
            }
            return View();
        }

        public ActionResult DeleteDirector(int id)
        {
            var director = db.Directors.FirstOrDefault(x => x.Director_ID == id);
            List<Movie> movies = db.Movies.Where(x => x.Director_ID == id).ToList();
            if (director != null)
            {
                //should remove all dependent records in other tables before removing the movie
                foreach (var movie in movies)
                {
                    db.Movies.Remove(movie);
                }
                db.Directors.Remove(director);
                db.SaveChanges();

            }
            return RedirectToAction("Directors");
        }

        [HttpGet]
        public ActionResult EditDirector(int id)
        {
            List<Movie> movies = db.Movies.Where(x => x.Director_ID == id).ToList();
            DirectorMovies directorMovies = new DirectorMovies
            {
                Movies = movies,
                Director = db.Directors.Single(x => x.Director_ID == id)
            };
            return View(directorMovies);
        }
        
        [HttpPost]
        public ActionResult EditDirector(DirectorMovies directorMovies)
        {
            try
            {

                db.Entry(directorMovies.Director).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("DirectorProfile", new RouteValueDictionary(new { Controller = "Admin", Action = "DirectorProfile", Id = directorMovies.Director.Director_ID }));

            }
            catch
            {
                return View();
            }
        }

    }
}