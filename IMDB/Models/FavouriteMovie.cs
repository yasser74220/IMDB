using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class FavouriteMovie
    {
        public User User_ID { get; set; }
        public Movie Movie_ID { get; set; }
        [Key]
        public int ID { get; set; }
    }
}