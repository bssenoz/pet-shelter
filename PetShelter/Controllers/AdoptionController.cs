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
                TempData["hata"] = "Please fill in the required fields";
                return RedirectToAction("Create");
            }

        }
    }
}
