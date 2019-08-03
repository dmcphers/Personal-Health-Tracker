using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Models;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPhysicalActivityService _physicalActivityService;
        private readonly IMentalActivityService _mentalActivityService;
        private readonly INutritionService _nutritionService;
        private readonly ISleepService _sleepService;


        public HomeController(IPhysicalActivityService physicalActivityService,
            IMentalActivityService mentalActivityService, INutritionService nutritionService,
            ISleepService sleepService)
        {
            _physicalActivityService = physicalActivityService;
            _mentalActivityService = mentalActivityService;
            _nutritionService = nutritionService;
            _sleepService = sleepService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DailySummary(SearchViewModel searchView)
        {
            //dayOfWeek = DayOfWeek.Monday;
            var searchDate = Convert.ToDateTime(searchView.dateViewModel.searchDate);
            DailySummaryViewModel dailySummaryViewModel = new DailySummaryViewModel();

            //var dateshort = test;

            dailySummaryViewModel.PA = _physicalActivityService.GetByDate(searchDate);
            dailySummaryViewModel.MA = _mentalActivityService.GetByDate(searchDate);
            dailySummaryViewModel.NUT = _nutritionService.GetByDate(searchDate);
            dailySummaryViewModel.SLP = _sleepService.GetByDate(searchDate);

            return View(dailySummaryViewModel);
        }

        public IActionResult DateRangeSummary(SearchViewModel searchView)
        {
            //dayOfWeek = DayOfWeek.Monday;
            var fromDate = Convert.ToDateTime(searchView.dateRangeViewModel.fromDate);
            var toDate = Convert.ToDateTime(searchView.dateRangeViewModel.toDate);

            DailySummaryViewModel dailySummaryViewModel = new DailySummaryViewModel();

            //var dateshort = test;

            dailySummaryViewModel.PA = _physicalActivityService.GetByDateRange(fromDate, toDate);
            dailySummaryViewModel.MA = _mentalActivityService.GetByDateRange(fromDate, toDate);
            dailySummaryViewModel.NUT = _nutritionService.GetByDateRange(fromDate, toDate);
            dailySummaryViewModel.SLP = _sleepService.GetByDateRange(fromDate, toDate);


            return View(dailySummaryViewModel);
        }

        public IActionResult DateRangeSummary2(SearchViewModel searchView)
        {
            //dayOfWeek = DayOfWeek.Monday;
            var fromDate = Convert.ToDateTime(searchView.dateRangeViewModel.fromDate);
            var toDate = Convert.ToDateTime(searchView.dateRangeViewModel.toDate);

            DailySummaryViewModel dailySummaryViewModel = new DailySummaryViewModel();

            //var dateshort = test;

            dailySummaryViewModel.PA = _physicalActivityService.GetByDateRange(fromDate, toDate);
            dailySummaryViewModel.MA = _mentalActivityService.GetByDateRange(fromDate, toDate);
            dailySummaryViewModel.NUT = _nutritionService.GetByDateRange(fromDate, toDate);
            dailySummaryViewModel.SLP = _sleepService.GetByDateRange(fromDate, toDate);


            return View(dailySummaryViewModel);
        }



        //[HttpPost]
        //public IActionResult Add(Mental_Activity newMental_Activity) // -> receive data from HTML FORM
        //{
        //    if (ModelState.IsValid) // all required fields are completed
        //    {
        //        // we should be able to add new activity
        //        _mentalActivityService.Create(newMental_Activity);
        //        // service recieves the new activity
        //        // service sends the new activity to the repository (saved)
        //        return RedirectToAction(nameof(Index)); // --> Index();
        //    }

        //    GetMentalActivityTypes();

        //    return View("Form");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
