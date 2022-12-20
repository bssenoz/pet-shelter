using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
    public class AnimalController : Controller
    {
        ShelterContext k = new ShelterContext();
        public IActionResult Index()
        {
            var animals = k.Animals;
            return View(animals);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Animal a)
        {
            if(ModelState.IsValid)
            {
                //a.DateProperty = DateTime.Now;
                k.Add(a);
                k.SaveChanges();
                return RedirectToAction("Index");

            } else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Create");
            }

        }


    }
}
