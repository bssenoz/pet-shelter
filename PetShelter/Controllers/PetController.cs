using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShelter.Models;

namespace PetShelter.Controllers
{
    public class PetController : Controller
    {
        ShelterContext k = new ShelterContext();
        public async Task<IActionResult> Index(string? SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var pets = from p in k.Pets select p;
            if (!String.IsNullOrEmpty(SearchString))
            {
                pets = pets.Where(p => p.Species.Contains(SearchString));
            }
            var petList = pets.ToList().OrderByDescending(r => r.PetId);
            return View(petList);
        }

        public async Task<IActionResult> Dog(string? SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var pet = (from a in k.Pets
                       where a.FamilyaId == 1
                       select a);
            if (!String.IsNullOrEmpty(SearchString))
            {
                pet = pet.Where(p => p.Species.Contains(SearchString));
            }
            var petList = pet.ToList().OrderByDescending(r => r.PetId);

            return View(petList);
        }
        public async Task<IActionResult> Cat(string? SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var pet = (from a in k.Pets
                       where a.FamilyaId == 2
                       select a);
            if (!String.IsNullOrEmpty(SearchString))
            {
                pet = pet.Where(p => p.Species.Contains(SearchString));
            }
            var petList = pet.ToList().OrderByDescending(r => r.PetId);
            return View(petList);
        }
        public async Task<IActionResult> Bird(string? SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var pet = (from a in k.Pets
                       where a.FamilyaId == 3
                       select a);
            if (!String.IsNullOrEmpty(SearchString))
            {
                pet = pet.Where(p => p.Species.Contains(SearchString));
            }
            var petList = pet.ToList().OrderByDescending(r => r.PetId);
            return View(petList);
        }
        [Authorize]
        public IActionResult Adoption(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "pet not found";
                return View("Hata");
            }
            var a = k.Pets.FirstOrDefault(x => x.PetId == id);

            if (a is null)
            {
                TempData["hata"] = "pet not found";
                return View("Hata");

            }
            Adoption b = new Adoption();
            b.Username = User.Identity.Name;
            b.PetId = a.PetId;
            b.Situation = false;
            b.HomePet = "";
            b.BeforePet = "";
            b.Adress = "";
            k.Add(b);
            k.SaveChanges();
            return View(b);
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
                TempData["hata"] = "Please fill in the required fields";
                return RedirectToAction("Create");
            }

        }

        [HttpPost]
        public IActionResult Form(int? id, Adoption a)
        {
            if (id != a.PetId)
            {
                TempData["hata"] = "No Updates";
                return View("Hata");
            }
             a.Username = User.Identity.Name;
            var b = k.Adoption.Max(q => q.Id);
            a.Id = b;
          
            k.Adoption.Update(a);
            k.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Form(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Edit part can't work";
                return View("Hata");
            }
            Adoption(id);
            var a = k.Adoption.Max(q => q.Id);
            var b = k.Adoption.FirstOrDefault(x => x.Id == a);
            return View(b);
        }
    }
}
