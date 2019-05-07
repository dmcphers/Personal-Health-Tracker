using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Domain.Models;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class Physical_ActivityController : Controller
    {
        private readonly IPhysicalActivityService _physicalActivityService;

        public Physical_ActivityController(IPhysicalActivityService physicalActivityService)
        {
            _physicalActivityService = physicalActivityService;
        }

        // Physical_Activity/Index
        public IActionResult Index()
        {
            var physicalActivities = _physicalActivityService.GetAllPhysicalActivities();
            return View(physicalActivities);
        }

        //// HTTP GET Physical_Activity/Add
        //public IActionResult Add()
        //{
        //    return View("Form");
        //}

        //[HttpPost]
        //public IActionResult Add(Physical_Activity newPhysical_Activity) // -> receive data from HTML FORM
        //{
        //    if (ModelState.IsValid) // all required fields are completed
        //    {
        //        // we should be able to add new activity
        //        Physical_Activities.Add(newPhysical_Activity);
        //        return View(nameof(Index), Physical_Activities);
        //    }

        //    return View("Form");
        //}

        //public IActionResult Detail(int id) // get id from URL
        //{
        //    // need to know what Id looking for
        //    var physical_Activity = Physical_Activities.Single(p => p.Id == id);

        //    return View(physical_Activity);
        //}

        //public IActionResult Delete(int id)
        //{
        //    var physical_activity = Physical_Activities.Single(p => p.Id == id);

        //    Physical_Activities.Remove(physical_activity);

        //    return View(nameof(Index), Physical_Activities);
        //}

        //public IActionResult Edit(int id) // --> get id from URL
        //{
        //    var physical_activity = Physical_Activities.Single(p => p.Id == id);

        //    return View("Form", physical_activity);
        //}

        //[HttpPost]
        //// get id from URL
        //// get updated activity from FORM
        //public IActionResult Edit(int id, Physical_Activity updatedPhysicalActivity)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    var oldActivity = Physical_Activities.Single(p => p.Id == id);

        //    oldActivity.Description = updatedPhysicalActivity.Description;
        //    oldActivity.Duration = updatedPhysicalActivity.Duration;
        //    oldActivity.CaloriesBurned = updatedPhysicalActivity.CaloriesBurned;
        //    oldActivity.dayOfWeek = updatedPhysicalActivity.dayOfWeek;

        //    return View(nameof(Index), Physical_Activities);
        //    }

        //    return View("Form", updatedPhysicalActivity); // By passing updated activity
        //                                                  // we trigger the logic
        //                                                  // for edit within the Form.cshtml
        //}
    }
}