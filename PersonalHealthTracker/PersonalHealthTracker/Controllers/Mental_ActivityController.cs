using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Domain.Model;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class Mental_ActivityController : Controller
    {
        private const string MENTALACTIVITYTYPES = "MentalActivityTypes";

        private readonly IMentalActivityService _mentalActivityService;
        private readonly IMentalActivityTypeService _mentalActivityTypeService;

        public Mental_ActivityController(IMentalActivityService mentalActivityService,
            IMentalActivityTypeService mentalActivityTypeService)
        {
            _mentalActivityService = mentalActivityService;
            _mentalActivityTypeService = mentalActivityTypeService;
        }

        // Mental_Activity/Index
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

        // HTTP GET Mental_Activity/Add
        public IActionResult Add()
        {

            GetMentalActivityTypes();

            return View("Form");
        }

        [HttpPost]
        public IActionResult Add(Mental_Activity newMental_Activity) // -> receive data from HTML FORM
        {
            if (ModelState.IsValid) // all required fields are completed
            {
                // we should be able to add new activity
                _mentalActivityService.Create(newMental_Activity);
                // service recieves the new activity
                // service sends the new activity to the repository (saved)
                return RedirectToAction(nameof(Index)); // --> Index();
            }

            GetMentalActivityTypes();

            return View("Form");
        }

        public IActionResult Detail(int id) // get id from URL
        {
            // need to know what Id looking for
            var mental_Activity = _mentalActivityService.GetById(id);

            return View(mental_Activity);
        }

        public IActionResult Delete(int id)
        {
            var succeeded = _mentalActivityService.Delete(id);

            if (!succeeded) // when delete fails (false)
            {
                // using tempdata because we are communicating between actions
                // from delete to index
                TempData.Add("Error", "Sorry, the activity could not be deleted. Try again later.");

            }
            return RedirectToAction(nameof(Index));

        }

        // property/edit/1
        public IActionResult Edit(int id) // --> get id from URL
        {
            var mental_activity = _mentalActivityService.GetById(id);

            GetMentalActivityTypes();

            return View("Form", mental_activity);
        }

        [HttpPost]
        // get id from URL
        // get updated activity from FORM
        public IActionResult Edit(int id, Mental_Activity updatedMentalActivity)
        {
            if (ModelState.IsValid)
            {
                _mentalActivityService.Update(updatedMentalActivity);

                return RedirectToAction(nameof(Index));
            }

            GetMentalActivityTypes();

            return View("Form", updatedMentalActivity); // By passing updated activity
                                                          // we trigger the logic
                                                          // for edit within the Form.cshtml
        }

        private void GetMentalActivityTypes()
        {
            var mentalActivityTypes = _mentalActivityTypeService.GetAll();
            ViewData.Add(MENTALACTIVITYTYPES, mentalActivityTypes);
        }
    }
}