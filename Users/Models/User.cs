using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Users.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool IsNew { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Login Name")]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Display(Name = "Your Real Name")]
        public string UserName { get; set; }

        [Display(Name = "Country")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Country { get; set; }

        [Display(Name = "Birth Date")]
        [Remote("BirthDateValidator", "Home")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"/\A[^@]+@([^@\.]+\.)+[^@\.]+\z/", ErrorMessage = "Incorrect format of your email")]
        public string Email { get; set; }
    }
}