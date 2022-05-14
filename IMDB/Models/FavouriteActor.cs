using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class FavouriteActor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int User_ID { get; set; }

        [Required]
        [ForeignKey("Actor")]
        public int Actor_ID { get; set; }

        // nav props
        public virtual User User { get; set; }
        public virtual Actor Actor { get; set; }
    }
}