﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceAssetTracker.Data;
using ServiceAssetTracker.Models.ResellerViewModels;

namespace ServiceAssetTracker.Controllers
{
    public class Purchase_OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Purchase_OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchase_Order
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purchase_Order.ToListAsync());
        }

        // GET: Purchase_Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase_Order = await _context.Purchase_Order
                .SingleOrDefaultAsync(m => m.PoId == id);
            if (purchase_Order == null)
            {
                return NotFound();
            }

            return View(purchase_Order);
        }

        // GET: Purchase_Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purchase_Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoId,ResellerId,CustomerId,OrderReference,ProductId,Price")] Purchase_Order purchase_Order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase_Order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchase_Order);
        }

        // GET: Purchase_Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase_Order = await _context.Purchase_Order.SingleOrDefaultAsync(m => m.PoId == id);
            if (purchase_Order == null)
            {
                return NotFound();
            }
            return View(purchase_Order);
        }

        // POST: Purchase_Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PoId,ResellerId,CustomerId,OrderReference,ProductId,Price")] Purchase_Order purchase_Order)
        {
            if (id != purchase_Order.PoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase_Order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Purchase_OrderExists(purchase_Order.PoId))
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
            return View(purchase_Order);
        }

        // GET: Purchase_Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase_Order = await _context.Purchase_Order
                .SingleOrDefaultAsync(m => m.PoId == id);
            if (purchase_Order == null)
            {
                return NotFound();
            }

            return View(purchase_Order);
        }

        // POST: Purchase_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase_Order = await _context.Purchase_Order.SingleOrDefaultAsync(m => m.PoId == id);
            _context.Purchase_Order.Remove(purchase_Order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Purchase_OrderExists(int id)
        {
            return _context.Purchase_Order.Any(e => e.PoId == id);
        }
    }
}
