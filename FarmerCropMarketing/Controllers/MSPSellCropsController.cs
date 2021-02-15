using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmerCropMarketing.Models.Class;
using FarmerCropMarketing.Models.Context;

namespace FarmerCropMarketing.Controllers
{
    public class MSPSellCropsController : Controller
    {
        private readonly AppDbContext _context;

        public MSPSellCropsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MSPSellCrops
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MSPSellCrops.Include(m => m.MSPCropsDetail);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MSPSellCrops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSPSellCrops = await _context.MSPSellCrops
                .Include(m => m.MSPCropsDetail)
                .FirstOrDefaultAsync(m => m.MSPSell_id == id);
            if (mSPSellCrops == null)
            {
                return NotFound();
            }

            return View(mSPSellCrops);
        }

        // GET: MSPSellCrops/Create
        public IActionResult Create()
        {
            ViewData["MSPCrops_id"] = new SelectList(_context.MSPCropsDetails, "MSPCrops_id", "Crops_description");
            return View();
        }

        // POST: MSPSellCrops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MSPSell_id,Farmers_name,Farmers_email,Farmers_mobile_no,Farmers_address,MSPCrops_id")] MSPSellCrops mSPSellCrops)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mSPSellCrops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MSPCrops_id"] = new SelectList(_context.MSPCropsDetails, "MSPCrops_id", "Crops_description", mSPSellCrops.MSPCrops_id);
            return View(mSPSellCrops);
        }

        // GET: MSPSellCrops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSPSellCrops = await _context.MSPSellCrops.FindAsync(id);
            if (mSPSellCrops == null)
            {
                return NotFound();
            }
            ViewData["MSPCrops_id"] = new SelectList(_context.MSPCropsDetails, "MSPCrops_id", "Crops_description", mSPSellCrops.MSPCrops_id);
            return View(mSPSellCrops);
        }

        // POST: MSPSellCrops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MSPSell_id,Farmers_name,Farmers_email,Farmers_mobile_no,Farmers_address,MSPCrops_id")] MSPSellCrops mSPSellCrops)
        {
            if (id != mSPSellCrops.MSPSell_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mSPSellCrops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MSPSellCropsExists(mSPSellCrops.MSPSell_id))
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
            ViewData["MSPCrops_id"] = new SelectList(_context.MSPCropsDetails, "MSPCrops_id", "Crops_description", mSPSellCrops.MSPCrops_id);
            return View(mSPSellCrops);
        }

        // GET: MSPSellCrops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSPSellCrops = await _context.MSPSellCrops
                .Include(m => m.MSPCropsDetail)
                .FirstOrDefaultAsync(m => m.MSPSell_id == id);
            if (mSPSellCrops == null)
            {
                return NotFound();
            }

            return View(mSPSellCrops);
        }

        // POST: MSPSellCrops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mSPSellCrops = await _context.MSPSellCrops.FindAsync(id);
            _context.MSPSellCrops.Remove(mSPSellCrops);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MSPSellCropsExists(int id)
        {
            return _context.MSPSellCrops.Any(e => e.MSPSell_id == id);
        }
    }
}
