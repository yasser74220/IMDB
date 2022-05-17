using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class FavouriteDirector  
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int User_ID { get; set; }

        [Required]
        [ForeignKey("Director")]
        public int Director_ID { get; set; }

        // nav props
        public virtual User User { get; set; }
        public virtual Director Director { get; set; }

    }
}