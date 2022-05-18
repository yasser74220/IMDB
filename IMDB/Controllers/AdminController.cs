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
using IMDB.Functions;
namespace IMDB.Controllers
{
    public class AdminController : Controller 
    {
        IMDBContext db = new IMDBContext();
        Dbdata dbData = new Dbdata();
        DbAdd DbAdd = new DbAdd();
        DbDelete DbDelete = new DbDelete();
        DbUpdate DbUpdate = new DbUpdate();
        public ActionResult Index()
        {
            List<Movie> movies = dbData.RetriveMovies().ToList();
            return View(movies);
        }
        [HttpGet]
        public ActionResult CreateMovie()
        {
            var directors = dbData.RetriveDirectors().ToList();
            var actors = dbData.RetriveActors().ToList();
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
                DbAdd.MovieDb(movieActorsDirectors.Movie);
                if (movieActorsDirectors.ActorsIds != null)
                {
                    foreach (var id in movieActorsDirectors.ActorsIds)
                    {
                     
                        var movieActor = new MovieActor
                        {
                            Actor_ID = id,
                            Movie_ID = movieActorsDirectors.Movie.Movie_ID
                        };
                        DbAdd.MovieActorDb(movieActor);
                    }
                }

                
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
      
        
          
            var directors = dbData.RetriveDirectors().ToList();
            var actors = dbData.RetriveActors().ToList();
            List<MovieActor> movieActors = dbData.RetriveMovieInMovieActors(id);
            var MovieActorsDirectors = new MovieActorsDirectors
            {
                Directors = directors,
                Actors = actors,
                Movie = dbData.RetriveMovies(id),
                MovieActors = movieActors
            };
            return View(MovieActorsDirectors);
        }

        [HttpPost]
        public ActionResult EditMovie(MovieActorsDirectors movieActorsDirectors, HttpPostedFileBase file, int id)
        {
            if (ModelState.IsValid)
            {
               

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

               // DbUpdate.MovieDb(movieActorsDirectors.Movie);
                DbAdd.MovieDb(movieActorsDirectors.Movie);
                foreach (var actorId in movieActorsDirectors.ActorsIds)
                {
                   DbAdd.MovieActorDb(actorId,movieActorsDirectors.Movie.Movie_ID);
                }
                return RedirectToAction("Index");

            }
            return View();
        }

        private void DeleteMovieAux(int id)
        {
            var movie = dbData.RetriveMovies(id);
            List<MovieActor> movieActors = dbData.RetriveMovieInMovieActors(id);
            if (movie != null)
            {
                //should remove all dependent records in other tables before removing the movie
                foreach (var movieActor in movieActors)
                {
                  DbDelete.ActorMoviesDb(movieActor);
                }
                DbDelete.MovieDb(movie);
            }
        }

        public ActionResult MovieDetails(int id)
        {
            List<MovieActor> movieActors = dbData.RetriveMovieInMovieActors(id).ToList();
            MovieActors_vm movieActors_vm = new MovieActors_vm
            {
                Movie = dbData.RetriveMovies(id),
               MovieActors = movieActors
            };
            return View(movieActors_vm);
        }

        /*Actor Profile*/

        public ActionResult Actors()
        {
            List<Actor> actors = dbData.RetriveActors().ToList();
            return View(actors);
        }

        public ActionResult ActorProfile(int id)
        {
            List<MovieActor> movieActors = dbData.RetriveMovieInMovieActors(id).ToList();
            ActorMovies actorMovies = new ActorMovies
            {
                MovieActors = movieActors,
                Actor = dbData.RetriveActors(id)
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
                foreach (var actor in oldActors)
                {
                    if (actorMovies.Actor.FirstName == actor.FirstName &&
                       actorMovies.Actor.LastName == actor.LastName &&
                       actorMovies.Actor.Age == actor.Age)
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate)
                    return RedirectToAction("Actors");

                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic);

                    file.SaveAs(path);

                    actorMovies.Actor.ImgPath = pic;
                }

                if (actorMovies.MoviesIds != null)
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
            var actor = dbData.RetriveActors(id);
            List<MovieActor> movieActors = dbData.RetriveMovieInMovieActors(id).ToList();
            if (actor != null)
            {
                //should remove all dependent records in other tables before removing the movie
                foreach (var movieActor in movieActors)
                {
                    DbDelete.ActorMoviesDb(movieActor);
                }
                DbDelete.ActorDb(actor);
                

            }
            return RedirectToAction("Actors");
        }

        [HttpGet]
        public ActionResult EditActor(int id)
        {
            List<MovieActor> movieActors = dbData.RetriveActorInMovieActors(id).ToList();

            List<Movie> movies = new List<Movie>();
            foreach (var movieActor in movieActors)
            {
                
               var movie = dbData.RetriveMovies(movieActor.Movie_ID);
                movies.Add(movie);
            }

            ActorMovies actorMovies = new ActorMovies
            {
                Movies = movies,
                MovieActors = movieActors, 
                Actor = dbData.RetriveActors(id)
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

             
                DbUpdate.ActorDb(actorMovies.Actor);
                

                return RedirectToAction("ActorProfile", new RouteValueDictionary(new { Controller = "Admin", Action = "ActorProfile", Id = actorMovies.Actor.Actor_ID }));

            }
            catch
            {
                return View();
            }
        }

        /*Director Profile*/

        public ActionResult Directors()
        {
            List<Director> directors = dbData.RetriveDirectors().ToList();

            return View(directors);
        }

        public ActionResult DirectorProfile(int id)
        {

            List<Movie> movies = dbData.RetrieveDirectorMovies(id);
            DirectorMovies directorMovies = new DirectorMovies
            {
                Movies = movies,
                Director = dbData.RetriveDirectors(id)
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
                List<Director> oldDirectors = dbData.RetriveDirectors().ToList();
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
                    DbAdd.DirectorDb(director);
                }

                return RedirectToAction("Directors");
            }
            return View();
        }

        public ActionResult DeleteDirector(int id)
        {
            var director = dbData.RetriveDirectors(id);
            List<Movie> movies = dbData.RetrieveDirectorMovies(id);
            if (director != null)
            {
                //should remove all dependent records in other tables before removing the movie
                foreach (var movie in movies)
                {
                    DbDelete.MovieDb(movie);
                }
                DbDelete.DirectorDb(director);

            }
            return RedirectToAction("Directors");
        }

        [HttpGet]
        public ActionResult EditDirector(int id)
        {
            List<Movie> movies = dbData.RetrieveDirectorMovies(id);
            DirectorMovies directorMovies = new DirectorMovies
            {
                Movies = movies,
                Director = dbData.RetriveDirectors(id)
            };
            return View(directorMovies);
        }

        [HttpPost]
        public ActionResult EditDirector(DirectorMovies directorMovies)
        {
            try
            {

              
                DbUpdate.DirectorDb(directorMovies.Director);
               

                return RedirectToAction("DirectorProfile", new RouteValueDictionary(new { Controller = "Admin", Action = "DirectorProfile", Id = directorMovies.Director.Director_ID }));

            }
            catch
            {
                return View();
            }
        }

    }
}