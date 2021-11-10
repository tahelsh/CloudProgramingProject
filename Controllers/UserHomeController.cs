using Microsoft.AspNetCore.Mvc;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Prediction()
        {
            return View("~/Views/UserHome/PredictionBigML.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Prediction([Bind("city,  season,  feelslike,  humidity,  weekday")] BigML pred)
        {
            if (pred.humidity == null && pred.feelslike == null)
                ViewBag.text = "";
            else
            {
                string ans = BigML.Icecream.PredictIcecream(pred.city, pred.season, pred.feelslike, pred.humidity, pred.weekday);

                ViewBag.text = "the prediction is " + ans;
            }
            return View("~/Views/UserHome/PredictionBigML.cshtml");

        }

    }
}
