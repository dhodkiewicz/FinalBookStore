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
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        [Required]
        public string Uemail { get; set; }

        [Required]
        public string Uconfirmemail { get; set; }

        [Required]
        public string Ubranch { get; set; }

        [Required]
        public string Ucomment { get; set; }

    }


}