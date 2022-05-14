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
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Second Name")]
        public string Lname { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "User Image")]
        public string Image { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public UserGender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }



    }

    public enum UserGender
    {
        Male,
        Female
    }
}