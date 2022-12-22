using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class RegisterController : Controller
    {
        ShelterContext k = new ShelterContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User u)
        {
         
            if (ModelState.IsValid)
            {
                k.Add(u);
                k.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Index");
            }

        }
    }
}
