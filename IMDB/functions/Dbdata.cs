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

namespace IMDB.Functions
{
    public class Dbdata : Controller
    {
        public IMDBContext context = new IMDBContext();
       //  private HttpServerUtilityBase Server;
        private User user = new User();
        private string file;
        private new List<Actor> actors = new List<Actor>();
        private Actor actor = new Actor();

        private new List<Movie> movies = new List<Movie>();
        private Movie movie = new Movie();

        private new List<MovieActor> movieActors = new List<MovieActor>();
        private List<MovieActor> actorMovies = new List<MovieActor>();

        private new List<Director> directors = new List<Director>();
        private Director director = new Director();

        private new List<Comment> comments = new List<Comment>();

        private new List<Like> likes = new List<Like>();
        private Like like = new Like();
        public string AddImg(HttpPostedFileBase File)
        {
            string picture = System.IO.Path.GetFileName(File.FileName);
            string path = System.IO.Path.Combine(Server.MapPath("~/Images/"), picture);
            File.SaveAs(path);
            return picture;
        }

        public User RetrieveUser(int userId)
        {
            user = context.Users.Find(userId);
            return user;
        }


        public List<Actor> RetriveActors()
        {
            actors = context.Actors.ToList();
            return actors;
        }

        public Actor RetriveActors(int actorId)
        {
            actor = context.Actors.SingleOrDefault(x => x.Actor_ID == actorId);
            return actor;
        }

        public List<Movie> RetriveMovies()
        {
            movies = context.Movies.ToList();
            return movies;
        }

        public Movie RetriveMovies(int movieId)
        {
            movie = context.Movies.Single(x => x.Movie_ID == movieId);
            return movie;
        }
        public List<Movie> RetrieveDirectorMovies(int? directorId)
        {
            movies = context.Movies.Where(x => x.Director_ID == directorId).ToList();
            return movies;
        }
        public List<MovieActor> RetriveMovieInMovieActors(int MovieId)
        {
            movieActors = context.MovieActors.Where(x => x.Movie_ID == MovieId).ToList();
            return movieActors;
        }
        public List<MovieActor> RetriveActorInMovieActors(int actorId)
        {
            movieActors = context.MovieActors.Where(x => x.Actor_ID==actorId).ToList();
            return movieActors;
        }

        public List<MovieActor> RetrieveActorMovies(int ActorId)
        {
            actorMovies = context.MovieActors.Where(x => x.Actor_ID == ActorId).ToList();
            return actorMovies;
        }
        public List<Director> RetriveDirectors()
        {
            directors = context.Directors.ToList();
            return directors;
        }
        public Director RetriveDirectors(int? directorId)
        {
            director = context.Directors.Single(x => x.Director_ID == directorId);
            return director;
        }

        /*  public List<Comment> RetrieveFilmComments(int MovieId)
         {
             Comments = context.Comments.Where(x => MovieId == x.Movie_ID);
             return Comments;
         }*/

        public Like RetrieveUserMovieLike(int UserId, int MovieId)
        {
            like = context.Likes.SingleOrDefault(x => MovieId == x.Movie_ID && x.User_ID == UserId);
            return like;
        }
    }

}