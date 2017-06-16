using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Users.Models
{
    public static class UserRepository
    {
        private static List<User> _allUsers;

        static UserRepository()
        {
            _allUsers = new List<User>
            {
                new User {Id = 1, BirthDate = new DateTime(1983, 10, 12), Country = "USA", Email = "usa@usa.com", LoginName = "usa", UserName = "Steve"},
                new User {Id = 2, BirthDate = new DateTime(2000, 3, 8), Country = "Ukraine", Email = "ukraine@ukraine.com", LoginName = "ukraine", UserName = "Oleg"},
                new User {Id = 3, BirthDate = new DateTime(1999, 1, 1), Country = "UK", Email = "uk@uk.com", LoginName = "uk", UserName = "Lee"}
            };
        }
        public static List<User> AllUsers { get { return _allUsers; } }
    }
}