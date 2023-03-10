using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShelter.Models;
using System.Data;

namespace PetShelter.Controllers
{
    public class PanelController : Controller
    {
        ShelterContext k = new ShelterContext();

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var animals = k.Pets;
            return View(animals);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Approve(int? id)
        {
            var a = k.Adoption.FirstOrDefault(x => x.Id == id);
            var b = k.Pets.FirstOrDefault(x => x.PetId == a.PetId); 
            if(b == null)
            {
                TempData["hata"] = "The pet has already been adopted.";
                return View("Hata");
            }
            a.Situation = true;
            k.Adoption.Update(a);
            k.SaveChanges();
            Delete(a.PetId);
            return View(a);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Reject(int? id)
        {
            var a = k.Adoption.FirstOrDefault(x => x.Id == id);
            k.Adoption.Remove(a);
            k.SaveChanges();
            return View(a);
        }
        [Authorize(Roles = "Admin")]

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Adoption a)
        {
             a.Situation = true;
             k.Add(a);
             k.SaveChanges();
             Delete(a.PetId);
             return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Adoption()
        {
            var adoptions = k.Adoption;
            return View(adoptions);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Edit(int? id, Pet a)
        {
            if (id != a.PetId)
            {
                TempData["hata"] = "No Updates";
                return View("Hata");
            }
            if (ModelState.IsValid)
            {
                k.Pets.Update(a);
                k.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "edit part can't work";
                return View("Hata");
            }
            var a = k.Pets.FirstOrDefault(x => x.PetId == id);
            if (a is null)
            {
                TempData["hata"] = "No pets found to edit";
                return View("Hata");

            }
            return View(a);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "delete part can't work";
                return View("Hata");
            }
            var y = k.Pets.FirstOrDefault(x => x.PetId == id);
            if (y is null)
            {
                TempData["hata"] = "No pets to delete";
                return View("Hata");

            }

            k.Pets.Remove(y);
            k.SaveChanges();
            var familya = k.Families.FirstOrDefault(x => x.Id == y.FamilyaId);
            familya.Count--;
            k.Families.Update(familya);
            k.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["role"] = "Admin";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pet a)
        {
            if (ModelState.IsValid)
            {
                k.Add(a);
                k.SaveChanges();
                var familya = k.Families.FirstOrDefault(x => x.Id == a.FamilyaId);
                familya.Count++;
                k.Families.Update(familya);
                k.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                TempData["hata"] = "Please fill in the required fields";
                return RedirectToAction("Create");
            }

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Families()
        {
            var families = k.Families;
            return View(families);
        }
        public IActionResult CreateFamilya()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateFamilya(Familya a)
        {
            if (ModelState.IsValid)
            {
                a.Count = 0;
                k.Add(a);
                k.SaveChanges();
                return RedirectToAction("Families");

            }
            else
            {
                TempData["hata"] = "Please fill in the required fields";
                return RedirectToAction("Create");
            }

        }

        [Authorize(Roles = "Admin")]
        public IActionResult FamilyaDelete(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Silme kısmı çalışamaz";
                return View("Hata");
            }
            var y = k.Families.FirstOrDefault(x => x.Id == id);
            var pets = (from a in k.Pets
                        where a.FamilyaId == id
                        select a);
            if (y is null)
            {
                TempData["hata"] = "Silinecek herhangi bir yazar yok";
                return View("Hata");

            }
            k.Families.Remove(y);

            foreach (var pet in pets)
            {
                k.Pets.Remove(pet);
            }
            k.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
