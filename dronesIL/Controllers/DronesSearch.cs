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
    public class DronesSearch : Controller
    {
        private readonly dronesILContext _context;

        public DronesSearch(dronesILContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Drone> drones = new List<Drone>();
            drones = _context.Drone.ToList();
            return View(drones);
        }
    }
}
