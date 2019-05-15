using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Domain.Model;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class Physical_ActivityController : Controller
    {
        private const string PHYSICALACTIVITYTYPES = "PhysicalActivityTypes";

        private readonly IPhysicalActivityService _physicalActivityService;
        private readonly IPhysicalActivityTypeService _physicalActivityTypeService;

        public Physical_ActivityController(IPhysicalActivityService physicalActivityService,
            IPhysicalActivityTypeService physicalActivityTypeService)
        {
            _physicalActivityService = physicalActivityService;
            _physicalActivityTypeService = physicalActivityTypeService;
        }

        // Physical_Activity/Index
        public IActionResult Index()
        {
            // check if got any error in TempData
            if(TempData["Error"] !=null)
            {
                // Pass that error to the ViewData because communicating between action and view
                ViewData.Add("Error", TempData["Error"]);
            }

            var physicalActivities = _physicalActivityService.GetAllPhysicalActivities();
            return View(physicalActivities);
        }

        // HTTP GET Physical_Activity/Add
        public IActionResult Add()
        {
            
            var physicalActivityTypes = _physicalActivityTypeService.GetAll();
            ViewData.Add(PHYSICALACTIVITYTYPES, physicalActivityTypes);

            return View("Form");
        }

        [HttpPost]
        public IActionResult Add(Physical_Activity newPhysical_Activity) // -> receive data from HTML FORM
        {
            if (ModelState.IsValid) // all required fields are completed
            {
                // we should be able to add new activity
                _physicalActivityService.Create(newPhysical_Activity);
                // service recieves the new activity
                // service sends the new activity to the repository (saved)
                return RedirectToAction(nameof(Index)); // --> Index();
            }

            return View("Form");
        }

        public IActionResult Detail(int id) // get id from URL
        {
            // need to know what Id looking for
            var physical_Activity = _physicalActivityService.GetById(id);

            return View(physical_Activity);
        }

        public IActionResult Delete(int id)
        {
            var succeeded = _physicalActivityService.Delete(id);

            if(!succeeded) // when delete fails (false)
            {
                // using tempdata because we are communicating between actions
                // from delete to index
                TempData.Add("Error","Sorry, the activity could not be deleted. Try again later.");
                
            }
            return RedirectToAction(nameof(Index));

        }

        // property/edit/1
        public IActionResult Edit(int id) // --> get id from URL
        {
            var physical_activity = _physicalActivityService.GetById(id);

            return View("Form", physical_activity);
        }

        [HttpPost]
        // get id from URL
        // get updated activity from FORM
        public IActionResult Edit(int id, Physical_Activity updatedPhysicalActivity)
        {
            if (ModelState.IsValid)
            {
                _physicalActivityService.Update(updatedPhysicalActivity);

                return RedirectToAction(nameof(Index));
            }

            return View("Form", updatedPhysicalActivity); // By passing updated activity
                                                          // we trigger the logic
                                                          // for edit within the Form.cshtml
        }
    }
}