using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Functions;

namespace IMDB.Functions
{

    public class DbDelete
    {
        Dbdata Dbdata = new Dbdata();
        private IMDBContext context = new IMDBContext();
        public void ActorDb(Actor actor)
        {
            var searchedActor = context.Actors.SingleOrDefault(x => x.Actor_ID == actor.Actor_ID);
            context.Actors.Remove(searchedActor);
            context.SaveChanges();
        }

        public void ActorMoviesDb(MovieActor movieActor)
        {
            var actorMovies = context.MovieActors.FirstOrDefault(x => movieActor.Actor_ID == x.Actor_ID);
            context.MovieActors.Remove(actorMovies);
            context.SaveChanges();
        }
        public void DirectorDb(Director director)
        {
            var searchedDirector = context.Directors.FirstOrDefault(x => x.Director_ID == director.Director_ID);
            context.Directors.Remove(searchedDirector);
            context.SaveChanges();
        }
        public void FilmComments(Comment comment)
        {
            var searchedComment = context.Comments.FirstOrDefault(x => x.Comment_ID == comment.Comment_ID);
            context.Comments.Remove(searchedComment);
            context.SaveChanges();
        }
        public void FilmLikes(Like like)
        {
            var searchedLike = context.Likes.FirstOrDefault(x => x.Like_ID == like.Like_ID);
            context.Likes.Remove(searchedLike);
            context.SaveChanges();
        }
        public void MovieDb(Movie movie)
        {
            var searchedMovie = context.Movies.FirstOrDefault(x => x.Movie_ID == movie.Movie_ID);
            context.Movies.Remove(searchedMovie);
            context.SaveChanges();
        }
    }
}