using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class FavouriteDirector
    {
        public User User_ID { get; set; }
        public Director Director_ID { get; set; }
        [Key]
        public int ID { get; set; }
    }
}