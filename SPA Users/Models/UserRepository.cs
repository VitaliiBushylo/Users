using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SPA_Users.Models
{
    public static class UserRepository
    {
        //static UserRepository()
        //{
        //    try
        //    {
        //        using (var db = new UsersDbContext())
        //        {
        //            if (!db.Users.Any())
        //            {
        //                var u1 = new User { Id = 1, FirstName = "Steve", LastName = "Pete" };
        //                var u2 = new User { Id = 2, FirstName = "Oleg", LastName = "Salo" };
        //                var u3 = new User { Id = 3, FirstName = "Lee", LastName = "Forman" };

        //                db.Users.AddRange(new List<User> { u1, u2, u3 });
        //                db.UserActivities.AddRange(new List<UserActivity>
        //                {
        //                    new UserActivity { User = u1, Activity = "Creted by default.", TimeStamp = DateTime.Now, Id = Guid.NewGuid()},
        //                    new UserActivity { User = u2, Activity = "Creted by default.", TimeStamp = DateTime.Now, Id = Guid.NewGuid()},
        //                    new UserActivity { User = u2, Activity = "Creted by default.", TimeStamp = DateTime.Now, Id = Guid.NewGuid()}
        //                });

        //                db.SaveChanges();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //}

        public static List<User> GetAllUsers()
        {
            using (var db = new UsersDbContext())
            {
                return db.Users.ToList();
            }
        }

        public static void Add(User user)
        {
            using (var db = new UsersDbContext())
            {
                var nextId = db.Users.Count() + 1;
                user.Id = nextId;

                db.Users.Add(user);
                db.UserActivities.Add(new UserActivity { User = user, Activity = "Creted by new user.", TimeStamp = DateTime.Now, Id = Guid.NewGuid() });
                db.SaveChanges();
            }
        }
    }
}