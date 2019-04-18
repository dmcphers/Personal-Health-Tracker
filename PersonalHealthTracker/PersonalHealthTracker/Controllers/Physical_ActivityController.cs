using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Models;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class Physical_ActivityController : Controller
    {
        private List<Physical_Activity> Physical_Activities = new List<Physical_Activity>();

        // Physical_Activity/Index
        public IActionResult Index()
        {
            return View(Physical_Activities);
        }

        // HTTP GET Physical_Activity/Add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Physical_Activity newPhysical_Activity)
        {
            Physical_Activities.Add(newPhysical_Activity);
           
            return View(nameof(Index), Physical_Activities);
        }
    }
}