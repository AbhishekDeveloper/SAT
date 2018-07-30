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
    public class Job_ReferenceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Job_ReferenceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Job_Reference
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Job_Reference.Include(j => j.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Job_Reference/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Reference = await _context.Job_Reference
                .Include(j => j.Customer)
                .SingleOrDefaultAsync(m => m.JobReferenceId == id);
            if (job_Reference == null)
            {
                return NotFound();
            }

            return View(job_Reference);
        }

        // GET: Job_Reference/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "TradingName");
            return View();
        }

        // POST: Job_Reference/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobReferenceId,CustomerReference,MojoReference,WorkflowReference,CustomerId")] Job_Reference job_Reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job_Reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "TradingName", job_Reference.CustomerId);
            return View(job_Reference);
        }

        // GET: Job_Reference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Reference = await _context.Job_Reference.SingleOrDefaultAsync(m => m.JobReferenceId == id);
            if (job_Reference == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "TradingName", job_Reference.CustomerId);
            return View(job_Reference);
        }

        // POST: Job_Reference/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobReferenceId,CustomerReference,MojoReference,WorkflowReference,CustomerId")] Job_Reference job_Reference)
        {
            if (id != job_Reference.JobReferenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job_Reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Job_ReferenceExists(job_Reference.JobReferenceId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "TradingName", job_Reference.CustomerId);
            return View(job_Reference);
        }

        // POST: Job_Reference/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job_Reference = await _context.Job_Reference.SingleOrDefaultAsync(m => m.JobReferenceId == id);
            _context.Job_Reference.Remove(job_Reference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Job_ReferenceExists(int id)
        {
            return _context.Job_Reference.Any(e => e.JobReferenceId == id);
        }
    }
}
