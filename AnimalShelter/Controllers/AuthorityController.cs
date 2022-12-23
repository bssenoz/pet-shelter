using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    public class AuthorityController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index2()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
