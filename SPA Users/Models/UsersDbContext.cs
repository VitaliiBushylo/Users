using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SPA_Users.Models
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}