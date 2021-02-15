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
    public class MSPCropsDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public MSPCropsDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MSPCropsDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.MSPCropsDetails.ToListAsync());
        }

        // GET: MSPCropsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSPCropsDetail = await _context.MSPCropsDetails
                .FirstOrDefaultAsync(m => m.MSPCrops_id == id);
            if (mSPCropsDetail == null)
            {
                return NotFound();
            }

            return View(mSPCropsDetail);
        }

        // GET: MSPCropsDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MSPCropsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MSPCrops_id,Crops_name,Crops_price,Crops_description,Crops_image,Crop_Buying_Staring_Date,Crop_Buying_End_Date")] MSPCropsDetail mSPCropsDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mSPCropsDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mSPCropsDetail);
        }

        // GET: MSPCropsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSPCropsDetail = await _context.MSPCropsDetails.FindAsync(id);
            if (mSPCropsDetail == null)
            {
                return NotFound();
            }
            return View(mSPCropsDetail);
        }

        // POST: MSPCropsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MSPCrops_id,Crops_name,Crops_price,Crops_description,Crops_image,Crop_Buying_Staring_Date,Crop_Buying_End_Date")] MSPCropsDetail mSPCropsDetail)
        {
            if (id != mSPCropsDetail.MSPCrops_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mSPCropsDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MSPCropsDetailExists(mSPCropsDetail.MSPCrops_id))
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
            return View(mSPCropsDetail);
        }

        // GET: MSPCropsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSPCropsDetail = await _context.MSPCropsDetails
                .FirstOrDefaultAsync(m => m.MSPCrops_id == id);
            if (mSPCropsDetail == null)
            {
                return NotFound();
            }

            return View(mSPCropsDetail);
        }

        // POST: MSPCropsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mSPCropsDetail = await _context.MSPCropsDetails.FindAsync(id);
            _context.MSPCropsDetails.Remove(mSPCropsDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MSPCropsDetailExists(int id)
        {
            return _context.MSPCropsDetails.Any(e => e.MSPCrops_id == id);
        }
    }
}
