﻿using dronesIL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

using System.Web;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dronesIL.Data;

namespace dronesIL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dronesILContext _context;
        public HomeController(ILogger<HomeController> logger, dronesILContext context)
        {
            _context = context;
        }


        //public HomeController(dronesILContext context)
        //{
        //    _context = context;
        //}
        public user ValidateUser(string mail, string pass)
        {
            /*Replace this query of code with you DB code.*/
            user user = null;
            user= (from users in _context.user
                                  where users.mail == mail && users.password == pass
                                  select users).FirstOrDefault();
            if (user!=null)
            {
                ViewData["user"] = user;
                return user;
            }
            else
            {
                ViewData["user"] = null;
                return null;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult logging()
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
