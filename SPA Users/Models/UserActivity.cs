using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA_Users.Models
{
    public class UserActivity
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public User User { get; set; }
        public string Activity { get; set; }
    }
}