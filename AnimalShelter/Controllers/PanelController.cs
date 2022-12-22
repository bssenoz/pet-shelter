using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelter.Controllers
{
    public class PanelController : Controller
    {
        //[Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
