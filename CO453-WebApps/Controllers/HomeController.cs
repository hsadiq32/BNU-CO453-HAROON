using CO453_WebApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;

namespace CO453_WebApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DistanceConverter(DistanceConverter converter)
        {
            return View(converter);
        }

        public IActionResult BmiCalculator(BMI model)
        {
            return View(model);
        }

        public IActionResult BmiResultM(BMI model)
        {
            ViewBag.BMIResult = model.BMIcalc(false);
            ViewBag.BMIDescription = model.BMIdescription(0);
            ViewBag.BMIColour = model.BMIdescription(1);
            return View();
        }

        public IActionResult BmiResultI(BMI model)
        {
            ViewBag.BMIResult = model.BMIcalc(true);
            ViewBag.BMIDescription = model.BMIdescription(0);
            ViewBag.BMIColour = model.BMIdescription(1);
            return View();
        }

        public IActionResult StudentMarks()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
