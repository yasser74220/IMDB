using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class MovieActors_vm
    {
        public Movie Movie { get; set; }
        public List<MovieActor> MovieActors { get; set; }
    }
}