using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;
using System.Data.Entity;

namespace IMDB.DataLayer
{
    public class IMDBContext : DbContext
    {
        public IMDBContext() : base("IMDB")
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavouriteActor> UserActors { get; set; }
        public DbSet<FavouriteDirector> UserDirectors { get; set; }
        public DbSet<FavouriteMovie> UserMovies { get; set; }
    }

}