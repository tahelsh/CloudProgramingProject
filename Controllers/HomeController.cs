using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsersContext _context;
        private readonly FlavorsContext _context2;

        public HomeController(ILogger<HomeController> logger, UsersContext context, FlavorsContext context2)
        {
            _logger = logger;
            _context = context;
            _context2 = context2;
        }

        public IActionResult Index()
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

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contant()
        {
            return View();
        }
        public IActionResult Icecreams()
        {
            ViewBag.Message = _context2.Flavors.ToList();//for combo box of flavors in the window
            return View();
        }
        public IActionResult UserHome()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }

        //async Task<IActionResult>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult LogIn([Bind("UserName,Password")] User users)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                foreach (var user in _context.User)
                {
                    if (user.UserName == users.UserName && user.Password == users.Password)
                    {
                        ViewBag.text = "true";
                        flag = true;
                        StaticFields.UserName = user.UserName;
                        StaticFields.IsUser = true;
                        return View("~/Views/Home/UserHome.cshtml");
                    }
                }
                if (flag == false)
                    ViewBag.text = "false";
            }
            return View();
            //return null;//איך מודיעים על שגיאה?
            //sessionStorage.isMeneger = true;
        }

        public IActionResult LogOut()
        {
            StaticFields.IsUser = false;
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Prediction()
        {
            return View("~/Views/Home/PredictionBigML.cshtml");
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

                ViewBag.text = "The prediction is " + ans;
            }
            return View("~/Views/Home/PredictionBigML.cshtml");

        }

    }
}
