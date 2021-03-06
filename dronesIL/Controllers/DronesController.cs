using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dronesIL.Data;
using dronesIL.Models;
using helpers.SessionHelper;

namespace dronesIL.Controllers
{
    public class DronesController : Controller
    {
        private readonly dronesILContext _context;

        public DronesController(dronesILContext context)
        {
            _context = context;
        }

        // GET: Drones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drone.ToListAsync());
        }

        // GET: Drones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drone = await _context.Drone
                .FirstOrDefaultAsync(m => m.droneId == id);
            if (drone == null)
            {
                return NotFound();
            }

            return View(drone);
        }

        // GET: Drones/Create
        [RequireAuthentication(true)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> Create([Bind("name,price,description,imageUrl,isEnterprise")] Drone drone)
        {
            if (ModelState.IsValid)
            {
                drone.createDate = DateTime.Now;
                drone.LastUpdateDate = DateTime.Now;
                _context.Drone.Add(drone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drone);
        }

        // GET: Drones/Edit/5
        [RequireAuthentication(true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drone = await _context.Drone.FindAsync(id);
            if (drone == null)
            {
                return NotFound();
            }
            return View(drone);
        }

        // POST: Drones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> Edit(int id, [Bind("droneId,name,price,description,imageUrl,isEnterprise")] Drone drone)
        {
            if (id != drone.droneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    drone.LastUpdateDate = DateTime.Now;
                    _context.Update(drone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DroneExists(drone.droneId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(drone);
        }

        // GET: Drones/Delete/5
        [RequireAuthentication(true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drone = await _context.Drone
                .FirstOrDefaultAsync(m => m.droneId == id);
            if (drone == null)
            {
                return NotFound();
            }

            return View(drone);
        }

        // POST: Drones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drone = await _context.Drone.FindAsync(id);
            _context.Drone.Remove(drone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DroneExists(int id)
        {
            return _context.Drone.Any(e => e.droneId == id);
        }
    }
}
