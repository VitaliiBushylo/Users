using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users.Models;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(UserRepository.AllUsers);
        }

        public ActionResult Register()
        {
            return View(new User());
        }
    }
}