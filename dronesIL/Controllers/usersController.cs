using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dronesIL.Data;
using dronesIL.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using helpers.SessionHelper;

namespace dronesIL.Controllers
{
    public class usersController : Controller
    {
        private readonly dronesILContext _context;

        public usersController(dronesILContext context)
        {
            _context = context;
        }

        // GET: users
        [RequireAuthentication(true)]
        public async Task<IActionResult> Index()
        {
            return View(await _context.user.ToListAsync());
        }

        // GET: users/Details/5
        [RequireAuthentication(true)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .FirstOrDefaultAsync(m => m.userId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: users/Create
        [RequireAuthentication(true)]
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> Create([Bind("userId,firstName,lastName,mail,phoneNumber,password")] user user)
        {
            user.createDate = DateTime.Now;
            user.lastUpdateDate = DateTime.Now;




            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: users/Edit/5
        [RequireAuthentication(true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> Edit(int id, [Bind("userId,firstName,lastName,mail,phoneNumber,password,isAdmin")] user user)
        {
            user.lastUpdateDate = DateTime.Now;
            if (id != user.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userExists(user.userId))
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
            return View(user);
        }

        // GET: users/Delete/5
        [RequireAuthentication(true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .FirstOrDefaultAsync(m => m.userId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.user.FindAsync(id);
            _context.user.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [RequireAuthentication(true)]
        private bool userExists(int id)
        {
            return _context.user.Any(e => e.userId == id);
        }

    }
}
