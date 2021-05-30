using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dronesIL.Data;
using dronesIL.Models;

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
                .FirstOrDefaultAsync(m => m.id == id);
            if (drone == null)
            {
                return NotFound();
            }

            return View(drone);
        }

        // GET: Drones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,price,createDate,LastUpdateDate,Manufacturer,imageUrl")] Drone drone)
        {
            if (ModelState.IsValid)
            {
                if (drone.imageUrl == null)
                {
                    drone.imageUrl = "data:image/jpeg;base64,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";

                }
                drone.createDate = DateTime.Now;
                drone.LastUpdateDate = DateTime.Now;
                _context.Add(drone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(drone);
        }

        // GET: Drones/Edit/5
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
        public async Task<IActionResult> Edit(int id, [Bind("id,name,price,createDate,LastUpdateDate,Manufacturer")] Drone drone)
        {
            if (id != drone.id)
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
                    if (!DroneExists(drone.id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drone = await _context.Drone
                .FirstOrDefaultAsync(m => m.id == id);
            if (drone == null)
            {
                return NotFound();
            }

            return View(drone);
        }

        // POST: Drones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drone = await _context.Drone.FindAsync(id);
            _context.Drone.Remove(drone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DroneExists(int id)
        {
            return _context.Drone.Any(e => e.id == id);
        }
    }
}
