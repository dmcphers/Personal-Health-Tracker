using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Domain.Model;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class NutritionController : Controller
    {
        private const string NUTRITIONTYPES = "NutritionTypes";

        private readonly INutritionService _nutritionService;
        private readonly INutritionTypeService _nutritionTypeService;

        public NutritionController(INutritionService nutritionService,
            INutritionTypeService nutritionTypeService)
        {
            _nutritionService = nutritionService;
            _nutritionTypeService = nutritionTypeService;
        }

        // Nutrition/Index
        public IActionResult Index()
        {
            // check if got any error in TempData
            if (TempData["Error"] != null)
            {
                // Pass that error to the ViewData because communicating between action and view
                ViewData.Add("Error", TempData["Error"]);
            }

            var nutritionRecs = _nutritionService.GetAllNutritionRecs();
            return View(nutritionRecs);
        }

        // HTTP GET Nutrition/Add
        public IActionResult Add()
        {

            GetNutritionTypes();

            return View("Form");
        }

        [HttpPost]
        public IActionResult Add(Nutrition newNutritionRec) // -> receive data from HTML FORM
        {
            if (ModelState.IsValid) // all required fields are completed
            {
                // we should be able to add new activity
                _nutritionService.Create(newNutritionRec);
                // service recieves the new nutrition record
                // service sends the new nutrition record to the repository (saved)
                return RedirectToAction(nameof(Index)); // --> Index();
            }

            GetNutritionTypes();

            return View("Form");
        }

        public IActionResult Detail(int id) // get id from URL
        {
            // need to know what Id looking for
            var nutritionRec = _nutritionService.GetById(id);

            return View(nutritionRec);
        }

        public IActionResult Delete(int id)
        {
            var succeeded = _nutritionService.Delete(id);

            if (!succeeded) // when delete fails (false)
            {
                // using tempdata because we are communicating between actions
                // from delete to index
                TempData.Add("Error", "Sorry, the nutrition record could not be deleted. Try again later.");

            }
            return RedirectToAction(nameof(Index));

        }

        // nutrition/edit/1
        public IActionResult Edit(int id) // --> get id from URL
        {
            var nutritionRec = _nutritionService.GetById(id);

            GetNutritionTypes();

            return View("Form", nutritionRec);
        }

        [HttpPost]
        // get id from URL
        // get updated nutrition record from FORM
        public IActionResult Edit(int id, Nutrition updatedNutritionRec)
        {
            if (ModelState.IsValid)
            {
                _nutritionService.Update(updatedNutritionRec);

                return RedirectToAction(nameof(Index));
            }

            GetNutritionTypes();

            return View("Form", updatedNutritionRec); // By passing updated nutrition record
                                                        // we trigger the logic
                                                        // for edit within the Form.cshtml
        }

        private void GetNutritionTypes()
        {
            var nutritionTypes = _nutritionTypeService.GetAll();
            ViewData.Add(NUTRITIONTYPES, nutritionTypes);
        }
    
    }
}