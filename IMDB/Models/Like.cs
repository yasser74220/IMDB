using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Like
    {
        public User User_ID { get; set; }
        public Movie Movie_ID { get; set; }
        [Key]
        public int Like_ID { get; set; }
        public bool like { get; set; }
    }
}