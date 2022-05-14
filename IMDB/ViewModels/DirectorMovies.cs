using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class DirectorMovies
    {
        public Director Director { get; set; }
        public List<Movie> Movies { get; set; }
    }
}