using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class MovieActorsDirectors
    {
        public List<Director> Directors { get; set; }
        public List<Actor> Actors { get; set; }
        public Movie Movie { get; set; }
        public List<int> ActorsIds { get; set; }
        public List<MovieActor> MovieActors { get; set; }
    }
}