using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SPA_Users.Models;

namespace SPA_Users.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public IEnumerable<User> GetAllUsers()
        {
            return UserRepository.GetAllUsers();
        }

        public User PostUser(User user)
        {
            UserRepository.Add(user);
            return user;
        }
    }
}
