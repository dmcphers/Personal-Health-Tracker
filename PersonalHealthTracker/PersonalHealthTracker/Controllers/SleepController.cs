using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Domain.Model;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class SleepController : Controller
    {
        private readonly ISleepService _sleepService;
        
        public SleepController(ISleepService sleepService)
        {
            _sleepService = sleepService;
        }

        // Sleep/Index
        public IActionResult Index()
        {
            // check if got any error in TempData
            if (TempData["Error"] != null)
            {
                // Pass that error to the ViewData because communicating between action and view
                ViewData.Add("Error", TempData["Error"]);
            }

            var sleepRecs = _sleepService.GetAllSleepRecs();
            return View(sleepRecs);
        }

        // HTTP GET Sleep/Add
        public IActionResult Add()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Add(Sleep newSleepRec) // -> receive data from HTML FORM
        {
            if (ModelState.IsValid) // all required fields are completed
            {
                // we should be able to add new sleep record
                _sleepService.Create(newSleepRec);
                // service recieves the new sleep record
                // service sends the new sleep record to the repository (saved)
                return RedirectToAction(nameof(Index)); // --> Index();
            }

            return View("Form");
        }

        public IActionResult Detail(int id) // get id from URL
        {
            // need to know what Id looking for
            var sleepRec = _sleepService.GetById(id);

            return View(sleepRec);
        }

        public IActionResult Delete(int id)
        {
            var succeeded = _sleepService.Delete(id);

            if (!succeeded) // when delete fails (false)
            {
                // using tempdata because we are communicating between actions
                // from delete to index
                TempData.Add("Error", "Sorry, the sleep record could not be deleted. Try again later.");

            }
            return RedirectToAction(nameof(Index));

        }

        // sleep/edit/1
        public IActionResult Edit(int id) // --> get id from URL
        {
            var sleepRec = _sleepService.GetById(id);

            return View("Form", sleepRec);
        }

        [HttpPost]
        // get id from URL
        // get updated sleep record from FORM
        public IActionResult Edit(int id, Sleep updatedSleepRec)
        {
            if (ModelState.IsValid)
            {
                _sleepService.Update(updatedSleepRec);

                return RedirectToAction(nameof(Index));
            }

            return View("Form", updatedSleepRec); // By passing updated sleep record
                                                      // we trigger the logic
                                                      // for edit within the Form.cshtml
        }
    }
}