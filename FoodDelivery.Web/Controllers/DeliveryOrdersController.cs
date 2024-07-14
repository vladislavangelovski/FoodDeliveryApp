using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Repository;

namespace FoodDelivery.Web.Controllers
{
    public class DeliveryOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeliveryOrders.Include(d => d.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeliveryOrders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryOrder = await _context.DeliveryOrders
                .Include(d => d.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryOrder == null)
            {
                return NotFound();
            }

            return View(deliveryOrder);
        }

        // GET: DeliveryOrders/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: DeliveryOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerId,Id")] DeliveryOrder deliveryOrder)
        {
            if (ModelState.IsValid)
            {
                deliveryOrder.Id = Guid.NewGuid();
                _context.Add(deliveryOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id", deliveryOrder.OwnerId);
            return View(deliveryOrder);
        }

        // GET: DeliveryOrders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);
            if (deliveryOrder == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id", deliveryOrder.OwnerId);
            return View(deliveryOrder);
        }

        // POST: DeliveryOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OwnerId,Id")] DeliveryOrder deliveryOrder)
        {
            if (id != deliveryOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryOrderExists(deliveryOrder.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id", deliveryOrder.OwnerId);
            return View(deliveryOrder);
        }

        // GET: DeliveryOrders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryOrder = await _context.DeliveryOrders
                .Include(d => d.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryOrder == null)
            {
                return NotFound();
            }

            return View(deliveryOrder);
        }

        // POST: DeliveryOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);
            if (deliveryOrder != null)
            {
                _context.DeliveryOrders.Remove(deliveryOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryOrderExists(Guid id)
        {
            return _context.DeliveryOrders.Any(e => e.Id == id);
        }
    }
}
