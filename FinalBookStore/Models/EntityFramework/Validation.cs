using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalBookStore.Models.EntityFramework
{
    public class Validation
    {
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Uemail { get; set; }

        [Required]
        [Compare ("Uemail")]
        [Display(Name = "Confirm Email")]
        public string Uconfirmemail { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public string Ubranch { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string Ucomment { get; set; }

    }


}