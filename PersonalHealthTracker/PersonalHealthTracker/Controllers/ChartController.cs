﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalHealthTracker.Domain.Model;
using PersonalHealthTracker.Models;
using PersonalHealthTrackerService.Services;

namespace PersonalHealthTracker.WebUI.Controllers
{
    public class ChartController : Controller
    {


        private readonly IPhysicalActivityService _physicalActivityService;
        private readonly IMentalActivityService _mentalActivityService;
        private readonly INutritionService _nutritionService;
        private readonly ISleepService _sleepService;


        public ChartController(IPhysicalActivityService physicalActivityService,
            IMentalActivityService mentalActivityService, INutritionService nutritionService,
            ISleepService sleepService)
        {
            _physicalActivityService = physicalActivityService;
            _mentalActivityService = mentalActivityService;
            _nutritionService = nutritionService;
            _sleepService = sleepService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult PAChart()
        {
            return View();
        }
        
        public JsonResult GetPAChartData(DateRangeViewModel dateRangeView)
        {
            //var fromDate = "07/12/2019";
            //var toDate = "07/13/2019";
            var fromDate = Convert.ToDateTime(dateRangeView.fromDate);
            var toDate = Convert.ToDateTime(dateRangeView.toDate);

            DailySummaryViewModel dailySummaryViewModel = new DailySummaryViewModel();

            dailySummaryViewModel.PA = _physicalActivityService.GetByDateRange(fromDate, toDate);
            
            return Json(dailySummaryViewModel.PA);
        }

        public IActionResult MAChart()
        {
            return View();
        }

        public JsonResult GetMAChartData(DateRangeViewModel dateRangeView)
        {
            //var fromDate = "07/12/2019";
            //var toDate = "07/13/2019";
            var fromDate = Convert.ToDateTime(dateRangeView.fromDate);
            var toDate = Convert.ToDateTime(dateRangeView.toDate);

            DailySummaryViewModel dailySummaryViewModel = new DailySummaryViewModel();

            dailySummaryViewModel.MA = _mentalActivityService.GetByDateRange(fromDate, toDate);

            return Json(dailySummaryViewModel.MA);
        }

        public IActionResult NUTChart()
        {
            return View();
        }

        public JsonResult GetNUTChartData(DateRangeViewModel dateRangeView)
        {
            //var fromDate = "07/12/2019";
            //var toDate = "07/13/2019";
            var fromDate = Convert.ToDateTime(dateRangeView.fromDate);
            var toDate = Convert.ToDateTime(dateRangeView.toDate);

            DailySummaryViewModel dailySummaryViewModel = new DailySummaryViewModel();

            dailySummaryViewModel.NUT = _nutritionService.GetByDateRange(fromDate, toDate);

            return Json(dailySummaryViewModel.NUT);
        }

        public IActionResult SLPChart()
        {
            return View();
        }

        public JsonResult GetSLPChartData(DateRangeViewModel dateRangeView)
        {
            //var fromDate = "07/12/2019";
            //var toDate = "07/13/2019";
            var fromDate = Convert.ToDateTime(dateRangeView.fromDate);
            var toDate = Convert.ToDateTime(dateRangeView.toDate);

            DailySummaryViewModel dailySummaryViewModel = new DailySummaryViewModel();

            dailySummaryViewModel.SLP = _sleepService.GetByDateRange(fromDate, toDate);
            
            return Json(dailySummaryViewModel.SLP);
        }

       

    }
}