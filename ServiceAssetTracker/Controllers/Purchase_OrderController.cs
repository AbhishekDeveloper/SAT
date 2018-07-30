using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceAssetTracker.Data;
using ServiceAssetTracker.Models.ResellerViewModels;
using ServiceAssetTracker.Models.CustomModels;

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
            // var applicationDbContext = _context.Purchase_Order.Include(p => p.Product);
            var applicationDbContext = _context.Purchase_Order
                .Join(_context.Reseller, p => p.ResellerId, r => r.ResellerId, (p, r) => new
                {
                    p.Product,
                    p.PoId,
                    r.TradingName,
                    p.CustomerId,
                    p.OrderReference,
                    p.Price
                })
                .Join(_context.Customer, rp => rp.CustomerId, cust => cust.CustomerId, (rp, cust) => new cmPurchaseOrder
                {
                    PoId = rp.PoId,
                    ResellerId = rp.TradingName,
                    CustomerId = cust.TradingName,
                    OrderReference = rp.OrderReference,
                    ProductId = rp.Product.Name,
                    Price = rp.Price
                });

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Purchase_Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationDbContext = _context.Purchase_Order.Where(m => m.PoId == id)
                .Join(_context.Reseller, p => p.ResellerId, r => r.ResellerId, (p, r) => new
                {
                    p.Product,
                    p.PoId,
                    r.TradingName,
                    p.CustomerId,
                    p.OrderReference,
                    p.Price
                })
                .Join(_context.Customer, rp => rp.CustomerId, cust => cust.CustomerId, (rp, cust) => new cmPurchaseOrder
                {
                    PoId = rp.PoId,
                    ResellerId = rp.TradingName,
                    CustomerId = cust.TradingName,
                    OrderReference = rp.OrderReference,
                    ProductId = rp.Product.Name,
                    Price = rp.Price
                });

            if (applicationDbContext == null)
            {
                return NotFound();
            }

            return View(await applicationDbContext.FirstOrDefaultAsync());
        }

        // GET: Purchase_Order/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name");
            ViewData["ResellerId"] = new SelectList(_context.Reseller, "ResellerId", "TradingName");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "TradingName");
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name", purchase_Order.ProductId);
            ViewData["ResellerId"] = new SelectList(_context.Product, "ResellerId", "TradingName");
            ViewData["CustomerId"] = new SelectList(_context.Product, "CustomerId", "TradingName");
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name", purchase_Order.ProductId);
            ViewData["ResellerId"] = new SelectList(_context.Reseller, "ResellerId", "TradingName", purchase_Order.ResellerId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "TradingName", purchase_Order.CustomerId);
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name", purchase_Order.ProductId);
            ViewData["ResellerId"] = new SelectList(_context.Product, "ResellerId", "TradingName");
            ViewData["CustomerId"] = new SelectList(_context.Product, "CustomerId", "TradingName");
            return View(purchase_Order);
        }

        // POST: Purchase_Order/Delete/5
        [HttpPost]
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
