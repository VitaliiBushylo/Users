using System.Collections.Generic;
using SPA_Users.Models;

namespace SPA_Users.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SPA_Users.Models.UsersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SPA_Users.Models.UsersDbContext context)
        {
            if (!context.Users.Any())
            {
                var u1 = new User { Id = 1, FirstName = "Steve", LastName = "Pete" };
                var u2 = new User { Id = 2, FirstName = "Oleg", LastName = "Salo" };
                var u3 = new User { Id = 3, FirstName = "Lee", LastName = "Forman" };

                context.Users.AddRange(new List<User> { u1, u2, u3 });
                context.UserActivities.AddRange(new List<UserActivity>
                        {
                            new UserActivity { User = u1, Activity = "Creted by default.", TimeStamp = DateTime.Now, Id = Guid.NewGuid()},
                            new UserActivity { User = u2, Activity = "Creted by default.", TimeStamp = DateTime.Now, Id = Guid.NewGuid()},
                            new UserActivity { User = u2, Activity = "Creted by default.", TimeStamp = DateTime.Now, Id = Guid.NewGuid()}
                        });

                context.SaveChanges();
            }
        }
    }
}
