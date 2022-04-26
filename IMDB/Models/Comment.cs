using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Comment
    {
        public User User_ID { get; set; }
        public Movie Movie_ID { get; set; }
        public String comment { get; set; }
        [Key]
        public int Comment_ID { get; set; }
    }
}