using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class ActorMovies
    {
        public Actor Actor { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public List<Movie> Movies { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}