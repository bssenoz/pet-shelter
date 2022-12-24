using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    public class AdoptionController : Controller
    {
        ShelterContext k = new ShelterContext();
        public IActionResult Index()
        {
            var adoption = k.Adoption;
            return View(adoption);
        }

        public IActionResult Create()
        {
            ViewData["role"] = "Admin";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Adoption a)
        {
            if (ModelState.IsValid)
            {
                k.Add(a);
                k.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Create");
            }

        }
    }
}
