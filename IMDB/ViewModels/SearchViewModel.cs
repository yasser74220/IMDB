﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Director> Directors { get; set; }
    }
}