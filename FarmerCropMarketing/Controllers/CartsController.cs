using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmerCropMarketing.Models;
using FarmerCropMarketing.Models.Context;

namespace FarmerCropMarketing.Controllers
{
    public class CartsController : Controller
    {
        private readonly AppDbContext _context;

        public CartsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Cart.Include(c => c.Crops).Include(c => c.Farmers);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Crops)
                .Include(c => c.Farmers)
                .FirstOrDefaultAsync(m => m.Cart_id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["Crops_id"] = new SelectList(_context.Crops, "Crops_id", "Crops_description");
            ViewData["Farmers_id"] = new SelectList(_context.Farmers, "Farmers_id", "Farmers_address");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cart_id,Farmers_id,Crops_id")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Crops_id"] = new SelectList(_context.Crops, "Crops_id", "Crops_description", cart.Crops_id);
            ViewData["Farmers_id"] = new SelectList(_context.Farmers, "Farmers_id", "Farmers_address", cart.Farmers_id);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["Crops_id"] = new SelectList(_context.Crops, "Crops_id", "Crops_description", cart.Crops_id);
            ViewData["Farmers_id"] = new SelectList(_context.Farmers, "Farmers_id", "Farmers_address", cart.Farmers_id);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cart_id,Farmers_id,Crops_id")] Cart cart)
        {
            if (id != cart.Cart_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Cart_id))
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
            ViewData["Crops_id"] = new SelectList(_context.Crops, "Crops_id", "Crops_description", cart.Crops_id);
            ViewData["Farmers_id"] = new SelectList(_context.Farmers, "Farmers_id", "Farmers_address", cart.Farmers_id);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Crops)
                .Include(c => c.Farmers)
                .FirstOrDefaultAsync(m => m.Cart_id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Cart_id == id);
        }
    }
}
