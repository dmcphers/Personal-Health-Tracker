using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class Mental_ActivityController : Controller
    {

        private readonly IMentalActivityService _mentalActivityService;
        private readonly IMentalActivityTypeService _mentalActivityTypeService;

        public Mental_ActivityController(IMentalActivityService mentalActivityService,
            IMentalActivityTypeService mentalActivityTypeService)
        {
            _mentalActivityService = mentalActivityService;
            _mentalActivityTypeService = mentalActivityTypeService;
        }

        // mental_Activity/Index
        public IActionResult Index()
        {
            // check if got any error in TempData
            if (TempData["Error"] != null)
            {
                // Pass that error to the ViewData because communicating between action and view
                ViewData.Add("Error", TempData["Error"]);
            }

            var mentalActivities = _mentalActivityService.GetAllMentalActivities();
            return View(mentalActivities);
        }
    }
}