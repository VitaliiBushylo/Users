using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Users.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool IsNew { get; set; }

        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Display(Name = "Your Real Name")]
        public string UserName { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}