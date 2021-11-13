using dronesIL.Data;
using dronesIL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Controllers
{
    public class SkylineController : Controller
    {
        private readonly dronesILContext _context;

        public SkylineController(dronesILContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
