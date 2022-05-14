using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;
namespace IMDB.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie movie { get; set; }

        public bool hadRated { get; set; }

        public Like like { get; set; }
        public Comment comment { get; set; }

        public int userId { get; set; }
        public int movieId { get; set; }


    }
}