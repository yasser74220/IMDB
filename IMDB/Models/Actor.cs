using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Actor
    {
        [Key]
        public int Actor_ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public byte[] Img { get; set; }

    }
}