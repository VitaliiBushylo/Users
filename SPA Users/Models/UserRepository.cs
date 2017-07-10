using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SPA_Users.Models
{
    public static class UserRepository
    {
        private static List<User> _allUsers;

        static UserRepository()
        {
            try
            {
                using (var db = new UsersDbContext())
                {
                    if (!db.Users.Any())
                    {
                        db.Users.AddRange(new List<User>
                    {
                        new User {Id = 1, FirstName = "Steve", LastName = "Pete"},
                        new User {Id = 2, FirstName = "Oleg", LastName = "Salo"},
                        new User {Id = 3, FirstName = "Lee", LastName = "Forman"}
                    });

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public static List<User> GetAllUsers()
        {
            using (var db = new UsersDbContext())
            {
                return db.Users.ToList();
            }
        }

        public static void Add(User user)
        {
            //var nextId = AllUsers.Max(u => u.Id) + 1;
            //user.Id = nextId;

            //AllUsers.Add(user);

            using (var db = new UsersDbContext())
            {
                var nextId = db.Users.Count() + 1;
                user.Id = nextId;

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}