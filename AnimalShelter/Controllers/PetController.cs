using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace AnimalShelter.Controllers
{
    public class PetController : Controller
    {
        ShelterContext k = new ShelterContext();
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var pets = from p in k.Pets select p;
            if(!String.IsNullOrEmpty(SearchString))
            {
                pets = pets.Where(p => p.Species.Contains(SearchString));
            } 
            var petList = pets.ToList().OrderByDescending(r => r.PetId);
            return View(petList);
        }
 
        public IActionResult Dog()
        {
            var pet=(from a in k.Pets
                      where a.FamilyaId == 1
             select a).ToList().OrderByDescending(r => r.PetId);
            return View(pet);
        }
        public IActionResult Cat()
        {
            var pet = (from a in k.Pets
                        where a.FamilyaId == 3
                        select a).ToList().OrderByDescending(r => r.PetId);
            return View(pet);
        }
        public IActionResult Bird()
        {
            var pet = (from a in k.Pets
                        where a.FamilyaId == 4
                        select a).ToList().OrderByDescending(r => r.PetId);
            return View(pet);
        }
        [Authorize]
        public IActionResult Adoption(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var a = k.Pets.FirstOrDefault(x => x.PetId == id);
            if (a is null)
            {
                TempData["hata"] = "Düzenlenece herhangi bir yazar yok";
                return View("Hata");

            }
            Adoption b = new Adoption();
            b.Username = User.Identity.Name;
            b.PetId = a.PetId;
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