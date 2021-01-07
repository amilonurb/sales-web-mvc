﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
                min = new DateTime(DateTime.Now.Year, 1, 1);

            if (!max.HasValue)
                max = DateTime.Now;

            ViewData["minDate"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = max.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(min, max);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
                min = new DateTime(DateTime.Now.Year, 1, 1);

            if (!max.HasValue)
                max = DateTime.Now;

            ViewData["minDate"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = max.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateGroupingAsync(min, max);
            return View(result);
        }
    }
}