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
    public class CropsController : Controller
    {
        private readonly AppDbContext _context;

        public CropsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Crops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crops.ToListAsync());
        }

        // GET: Crops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crops = await _context.Crops
                .FirstOrDefaultAsync(m => m.Crops_id == id);
            if (crops == null)
            {
                return NotFound();
            }

            return View(crops);
        }

        // GET: Crops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Crops_id,Crops_name,Crops_quantity,Crops_price,Crops_description,Crops_image,Farmers_id")] Crops crops)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crops);
        }

        // GET: Crops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crops = await _context.Crops.FindAsync(id);
            if (crops == null)
            {
                return NotFound();
            }
            return View(crops);
        }

        // POST: Crops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Crops_id,Crops_name,Crops_quantity,Crops_price,Crops_description,Crops_image,Farmers_id")] Crops crops)
        {
            if (id != crops.Crops_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CropsExists(crops.Crops_id))
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
            return View(crops);
        }

        // GET: Crops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crops = await _context.Crops
                .FirstOrDefaultAsync(m => m.Crops_id == id);
            if (crops == null)
            {
                return NotFound();
            }

            return View(crops);
        }

        // POST: Crops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crops = await _context.Crops.FindAsync(id);
            _context.Crops.Remove(crops);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CropsExists(int id)
        {
            return _context.Crops.Any(e => e.Crops_id == id);
        }
    }
}
