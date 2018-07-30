using System;
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
    public class StockTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StockTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockTypes.ToListAsync());
        }

        // POST: StockTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StockType stockType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockType);
        }

        // POST: StockTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StockType stockType)
        {
            if (id != stockType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTypeExists(stockType.Id))
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
            return View(stockType);
        }

        // POST: StockTypes/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockType = await _context.StockTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.StockTypes.Remove(stockType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTypeExists(int id)
        {
            return _context.StockTypes.Any(e => e.Id == id);
        }
    }
}
