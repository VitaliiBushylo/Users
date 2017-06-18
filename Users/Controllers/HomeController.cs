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
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                UserRepository.AllUsers.First(u => u.Id == id).IsNew = true;
               
                //RouteData.Values.Remove("id");
            }
            else
            {
                UserRepository.AllUsers.ForEach(u => u.IsNew = false);
            }

            RouteData.Values.Remove("id");

            return View(UserRepository.AllUsers);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var nextId = UserRepository.AllUsers.Max(u => u.Id) + 1;
            user.Id = nextId;
            UserRepository.AllUsers.Add(user);
            
           return RedirectToAction("Index", new { id = nextId });
        }
    }
}