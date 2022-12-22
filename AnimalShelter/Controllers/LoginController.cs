using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User p)
        {
            ShelterContext k = new ShelterContext();
            var adminuserinfo = k.Users.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (adminuserinfo != null)
            {
                return RedirectToAction("Index", "Animal");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
