using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IActionResult Adoption(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var a = k.Animals.FirstOrDefault(x => x.AnimalId == id);
            if (a is null)
            {
                TempData["hata"] = "Düzenlenece herhangi bir yazar yok";
                return View("Hata");

            }
            Adoption b = new Adoption();
            b.Username = User.Identity.Name;
            b.AnimalId = a.AnimalId;
            b.Situation = false;
            k.Add(b);
            k.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        
        public IActionResult Adoption(Adoption a)
        {
            a.Username = User.Identity.Name;
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