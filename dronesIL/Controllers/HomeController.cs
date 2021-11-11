using dronesIL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

using System.Web;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dronesIL.Data;
using helpers.SessionHelper;
using Newtonsoft.Json;

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
            try
            {


                /*Replace this query of code with you DB code.*/
                user user = null;
                user = (from users in _context.user
                        where users.mail == mail && users.password == pass
                        select users).FirstOrDefault();
                user.connectUser(HttpContext.Session);
                return user;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [RequireAuthentication(true)]
        public IActionResult admin()
        {
            return View();
            
        }
        [RequireAuthentication(true)]
        public IActionResult Reports()
        {
           
            return View();
        }
        [HttpGet]
        [RequireAuthentication(true)]
        public string GetDaysReport()
        {
            List<Order> orders = _context.Order.ToList();
            var groupedOrders = orders.GroupBy(g => g.orderDateTime.Date, v => v).Select(s => new  { name = s.Key, value = s.Sum(su => su.Sum) }).ToList();
            return JsonConvert.SerializeObject(groupedOrders);
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
        public IActionResult unAutorized()
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
