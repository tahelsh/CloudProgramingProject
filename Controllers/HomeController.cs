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

        public HomeController(ILogger<HomeController> logger, UsersContext context)
        {
            _logger = logger;
            _context = context;
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
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn([Bind("UserName,Password")] User users)
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
                        return View("~/Views/UserHome/Index.cshtml",user);
                    }
                }
                if (flag == false)
                    ViewBag.text = "false";
            }
            return View();
            //return null;//איך מודיעים על שגיאה?
            //sessionStorage.isMeneger = true;
        }

    }
}
