using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShelter.Models;
using System.Data;

namespace PetShelter.Controllers
{
    public class AdoptionController : Controller
    {
        ShelterContext k = new ShelterContext();
        public IActionResult Index()
        {
            var adoption = k.Adoption;
            return View(adoption);
        }
        [HttpPost]
        public IActionResult Formaa(int? id, Adoption a)
        {
           // var a = k.Pets.FirstOrDefault(x => x.PetId == id);
            //if (id != a.Id)
            //{
            //    TempData["hata"] = "Güncelleme Yapılmaz";
            //    return View("Hata");
            //}
            if (ModelState.IsValid)
            {
                Adoption b = new Adoption();
                b.Username = User.Identity.Name;
                b.PetId = a.PetId;
                b.Situation = false;
                k.Add(b);
                k.SaveChanges();
            }
            return View();
        }
       // [Authorize(Roles = "Admin")]
        public IActionResult Formaa(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Düzenleme kısmı çalışamaz";
                return View("Hata");
            }
            var a = k.Pets.FirstOrDefault(x => x.PetId == id);
            Adoption b = new Adoption();
            b.Username = User.Identity.Name;
            b.PetId = a.PetId;
            b.Situation = false;
            //k.Add(b);
            //k.SaveChanges();
            if (a is null)
            {
                TempData["hata"] = "Düzenlenece herhangi bir yazar yok";
                return View("Hata");

            }
            return View(b);
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
        public IActionResult Form(int? id)
        {
            var a = k.Pets.FirstOrDefault(x => x.PetId == id);
            Adoption b = new Adoption();
            b.Username = User.Identity.Name;
            b.PetId = a.PetId;
            b.Situation = false;
            b.HomePet = "";
            b.BeforePet = "";
            b.Adress = "";
            k.Add(a);
            k.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult Form(Adoption a)
        {
            a.Username = User.Identity.Name;
            if (ModelState.IsValid)
            {
                k.Add(a);
                k.SaveChanges();
                return RedirectToAction("Index","Pet");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Create");
            }

        }
    }
}
