using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class FavouriteActor
    {
        public User User_ID { get; set; }
        public Actor Actor_ID { get; set; }
        [Key]
        public int ID { get; set; }
    }
}