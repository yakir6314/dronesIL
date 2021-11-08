﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dronesIL.Data;
using dronesIL.Models;
using helpers.SessionHelper;
using Newtonsoft.Json.Linq;

namespace dronesIL.Controllers
{
    public class OrdersController : Controller
    {
        private readonly dronesILContext _context;

        public OrdersController(dronesILContext context)
        {
            _context = context;
        }

        // GET: Orders
        [RequireAuthentication(true)]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.orderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create

        [RequireAuthentication(true)]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpGet]
        public List<Order> GetAllOrdersForMaps()
        {
            List<Order> addresses = _context.Order.OrderByDescending(o=>o.orderId).Take(10).ToList();
            return addresses;

        }

        [HttpPost]
        public IActionResult goToBasket(List<Drone> drones)
        {
            Order order = new Order
            {
                drones = drones,
                Sum = drones.Sum(s => s.price)
            };
            return PartialView("~/Views/Orders/Create.cshtml", order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.orderDateTime = DateTime.Now;
                user u = SessionHelper.GetObjectFromJsoFromSessionn<user>(HttpContext.Session, "user");
                if (u != null)
                {
                    order.userId = u.userId;
                }
                _context.Order.Add(order);
                //_context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home"); ;
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        [RequireAuthentication(true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> Edit(int id, [Bind("id,orderDateTime,city,street,streetNum,sum,orderStatus")] Order order)
        {
            if (id != order.orderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.orderId))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        [RequireAuthentication(true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.orderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RequireAuthentication(true)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [RequireAuthentication(true)]
        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.orderId == id);
        }
    }
}
