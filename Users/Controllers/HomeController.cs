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

        [HttpGet]
        public ActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var nextId = UserRepository.AllUsers.Max(u => u.Id) + 1;
                user.Id = nextId;
                UserRepository.AllUsers.Add(user);

                TempData["NewcomerId"] = nextId; 
            }

           return RedirectToAction("Index");
        }

        public JsonResult BirthDateValidator(DateTime birthDate)
        {
            if (birthDate < DateTime.Now && birthDate != DateTime.MinValue)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please enter a birth date value", JsonRequestBehavior.AllowGet);
            }
        }
    }
}