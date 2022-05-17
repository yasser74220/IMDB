using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IMDB.Models;
namespace IMDB.DataLayer
{
    public class IData : IMDBContext
    {
        public IMDBContext context { get; set; }
        private HttpServerUtilityBase Server;
        private User User { get; set; }
        private string file { get; set; }
        private new List<Actor> Actors { get; set; }
        private Actor Actor { get; set; }

        private new List<Movie> Movies { get; set; }
        private Movie Movie { get; set; }

        private new List<MovieActor> MovieActors { get; set; }
        private List<MovieActor> ActorMovies { get; set; }

        private new List<Director> Directors { get; set; }
        private Director Director { get; set; }

        private new List<Comment> Comments { get; set; }

        private new List<Like> Likes { get; set; }
        private Like Like { get; set; }
        public string AddImg(HttpPostedFileBase File)
        {
            string picture = System.IO.Path.GetFileName(File.FileName);
            string path = System.IO.Path.Combine(Server.MapPath("~/ViewAssets/"), picture);
            File.SaveAs(path);
            return picture;
        }

        public User RetrieveUser(int userId)
        {
            User = context.Users.Find(userId);
            return User;
        }


        public List<Actor> RetriveActors()
        {
            Actors = context.Actors.ToList();
            return Actors;
        }

        public Actor RetriveActors(int actorId)
        {
            Actor = context.Actors.SingleOrDefault(x => x.Actor_ID == actorId);
            return Actor;
        }

        public List<Movie> RetriveMovies()
        {
            Movies = context.Movies.ToList();
            return Movies;
        }

        public Movie RetriveMovies(int movieId)
        {
            Movie = context.Movies.Single(x => x.Movie_ID == movieId);
            return Movie;
        }
        public List<Movie> RetrieveDirectorMovies(int? directorId)
        {
            Movies = context.Movies.Where(x => x.Director_ID == directorId).ToList();
            return Movies;
        }
        public List<MovieActor> RetriveMovieActors(int MovieId)
        {
            MovieActors = context.MovieActors.Where(x => x.Movie_ID == MovieId).ToList();
            return MovieActors;
        }

        public List<MovieActor> RetrieveActorMovies(int ActorId)
        {
            ActorMovies = context.MovieActors.Where(x => x.Actor_ID == ActorId).ToList();
            return ActorMovies;
        }
        public List<Director> RetriveDirectors()
        {
            Directors = context.Directors.ToList();
            return Directors;
        }
        public Director RetriveDirectors(int? directorId)
        {
            Director = context.Directors.Single(x => x.Director_ID == directorId);
            return Director;
        }

        /*  public List<Comment> RetrieveFilmComments(int MovieId)
         {
             Comments = _context.Comments.Where(x => MovieId == x.Movie_ID);
             return Comments;
         }*/

        public Like RetrieveUserMovieLike(int UserId, int MovieId)
        {
            Like = context.Likes.SingleOrDefault(x => MovieId == x.Movie_ID && x.User_ID == UserId);
            return Like;
        }
    }
   
}