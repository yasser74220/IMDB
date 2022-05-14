using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class EditProfile
    {

        public User user { get; set; }
        public FavouriteActor favouriteActor { get; set; }
        public FavouriteDirector favouriteDirector { get; set; }
        public FavouriteMovie favouriteMovie { get; set; }
        public List<Actor> actor { get; set; }
        public List<Director> director { get; set; }
        public List<Movie> movie { get; set; }

    }
}