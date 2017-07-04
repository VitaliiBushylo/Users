using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SPA_Users.Models;

namespace SPA_Users.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<User> GetAllUsers()
        {
            return UserRepository.AllUsers;
        }
    }
}
