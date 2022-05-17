using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class EditProfile
    {

        public User User { get; set; }
        public User TempUser { get; set; }
        public List<FavouriteActor> FavouriteActors { get; set; }
        public List<FavouriteDirector> FavouriteDirectors { get; set; }
        public List<FavouriteMovie> FavouriteMovies { get; set; }

        public List<int> FavouriteActorsIds { get; set; }
        public List<int> FavouriteDirectorsIds { get; set; }
        public List<int> FavouriteMoviesIds { get; set; }

        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }
        public List<Movie> Movies { get; set; }

    }
}