using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Like
    {
        
        [Required]
        [ForeignKey("User")]
        public int User_ID { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int Movie_ID { get; set; }

        [Required]
        public userLike like { get; set; }

        // nav props

        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
    public enum userLike
    {
        Dislike = 0,
        Like = 1
    }
}