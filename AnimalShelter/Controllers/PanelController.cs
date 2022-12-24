using AnimalShelter.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AnimalShelter.Controllers
{
    public class PanelController : Controller
        
    {
        ShelterContext k = new ShelterContext();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var animals = k.Animals;
            return View(animals);
        }
        public IActionResult Adoption()
        {
            var adoptions = k.Adoption;
            return View(adoptions);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Animal a)
        {
            if (id != a.AnimalId)
            {
                TempData["hata"] = "Güncelleme Yapılmaz";
                return View("Hata");
            }
            if (ModelState.IsValid)
            {
                k.Animals.Update(a);
                k.SaveChanges();
                return RedirectToAction("Index");
            }
            //TempData["hata"] = "Lütfen verileri eksiksiz girin";
            return View();
        }
        public IActionResult Edit(int? id)
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
            return View(a);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Silme kısmı çalışamaz";
                return View("Hata");
            }
            var y = k.Animals.FirstOrDefault(x => x.AnimalId == id);
            if (y is null)
            {
                TempData["hata"] = "Silinecek herhangi bir yazar yok";
                return View("Hata");

            }

            k.Animals.Remove(y);
            k.SaveChanges();
            //TempData["msj"] = y.YazarAd + " adlı yazar silindi";
            return RedirectToAction("Index");


        }
        //[Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["role"] = "Admin"; 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Animal a)
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

        //[Authorize(Roles = "Admin")]


    }
}