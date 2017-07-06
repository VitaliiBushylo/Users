using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA_Users.Models
{
    public static class UserRepository
    {
        private static List<User> _allUsers;

        static UserRepository()
        {
            _allUsers = new List<User>
            {
                new User {Id = 1, FirstName = "Steve", LastName = "Pete"},
                new User {Id = 2, FirstName = "Oleg", LastName = "Salo"},
                new User {Id = 3, FirstName = "Lee", LastName = "Forman"}
            };
        }
        public static List<User> AllUsers { get { return _allUsers; } }

        public static void Add(User user)
        {
            var nextId = AllUsers.Max(u => u.Id) + 1;
            user.Id = nextId;

            AllUsers.Add(user);
        }
    }
}