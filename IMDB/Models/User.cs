using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public String Email{ get; set; }
        public String Passward { get; set; }
        public int Role_ID { get; set; }
        public byte[] Img { get; set; }

    }
}