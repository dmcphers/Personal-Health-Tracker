﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Models;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class Physical_ActivityController : Controller
    {
        private List<Physical_Activity> Physical_Activities = new List<Physical_Activity>
        {
            new Physical_Activity {Id = 1, Description = "Jogging", Duration = 30, CaloriesBurned = 200, dayOfWeek = DayOfWeek.Monday },
            new Physical_Activity {Id = 2, Description = "Walking", Duration = 40, CaloriesBurned = 180, dayOfWeek = DayOfWeek.Tuesday}
        };

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
        public IActionResult Add(Physical_Activity newPhysical_Activity) // -> receive data from HTML FORM
        {
            Physical_Activities.Add(newPhysical_Activity);
           
            return View(nameof(Index), Physical_Activities);
        }

        public IActionResult Detail(int id) // get id from URL
        {
            // need to know what Id looking for
            var physical_Activity = Physical_Activities.Single(p => p.Id == id);

            return View(physical_Activity);
        }

        public IActionResult Delete(int id)
        {
            var physical_activity = Physical_Activities.Single(p => p.Id == id);

            Physical_Activities.Remove(physical_activity);

            return View(nameof(Index), Physical_Activities);
        }
    }
}