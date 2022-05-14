using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Movie
    {
        [Key]
        public int Movie_ID { get; set; }

        [Required]
        [ForeignKey("Director")]
        public int Director_ID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Movie Name")]
        public string Movie_Name { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Movie Image")]
        public string ImgPath { get; set; }


        // nav props
        public virtual Director Director { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }

    }
}