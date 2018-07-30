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
    public class Reseller_ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Reseller_ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reseller_Service
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reseller_Service.Include(r => r.Categories).Include(r => r.Reseller);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reseller_Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseller_Service = await _context.Reseller_Service
                .Include(r => r.Categories)
                .Include(r => r.Reseller)
                .SingleOrDefaultAsync(m => m.ResellerServiceId == id);
            if (reseller_Service == null)
            {
                return NotFound();
            }

            return View(reseller_Service);
        }

        // GET: Reseller_Service/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["ResellerId"] = new SelectList(_context.Reseller, "ResellerId", "TradingName");
            return View();
        }

        // POST: Reseller_Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResellerServiceId,ResellerId,ShortDescription,CategoryId,Task,Price,Metric")] Reseller_Service reseller_Service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseller_Service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", reseller_Service.CategoryId);
            ViewData["ResellerId"] = new SelectList(_context.Reseller, "ResellerId", "TradingName", reseller_Service.ResellerId);
            return View(reseller_Service);
        }

        // GET: Reseller_Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseller_Service = await _context.Reseller_Service.SingleOrDefaultAsync(m => m.ResellerServiceId == id);
            if (reseller_Service == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", reseller_Service.CategoryId);
            ViewData["ResellerId"] = new SelectList(_context.Reseller, "ResellerId", "TradingName", reseller_Service.ResellerId);
            return View(reseller_Service);
        }

        // POST: Reseller_Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResellerServiceId,ResellerId,ShortDescription,CategoryId,Task,Price,Metric")] Reseller_Service reseller_Service)
        {
            if (id != reseller_Service.ResellerServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseller_Service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Reseller_ServiceExists(reseller_Service.ResellerServiceId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", reseller_Service.CategoryId);
            ViewData["ResellerId"] = new SelectList(_context.Reseller, "ResellerId", "TradingName", reseller_Service.ResellerId);
            return View(reseller_Service);
        }

        // POST: Reseller_Service/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reseller_Service = await _context.Reseller_Service.SingleOrDefaultAsync(m => m.ResellerServiceId == id);
            _context.Reseller_Service.Remove(reseller_Service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Reseller_ServiceExists(int id)
        {
            return _context.Reseller_Service.Any(e => e.ResellerServiceId == id);
        }
    }
}
