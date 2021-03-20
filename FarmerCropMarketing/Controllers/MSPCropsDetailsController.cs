using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmerCropMarketing.Models.Class;
using FarmerCropMarketing.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using FarmerCropMarketing.Models.viewmodel;
using System.IO;

namespace FarmerCropMarketing.Controllers
{
    public class MSPCropsDetailsController : Controller
    {
        
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly AppDbContext _context;

        public MSPCropsDetailsController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment hostEnvironment,
            AppDbContext context)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.hostEnvironment = hostEnvironment;
            this._context = context;
        }
        // GET: MSPCropsDetails
        public async Task<IActionResult> Index()
        {
            var x =await _context.MSPCropsDetails.ToListAsync();
            var allmspcrop = new List<editmspcrop>();
            foreach(var y in x)
                {
                var crop = new editmspcrop
                {
                    Crops_description = y.Crops_description,
                    ExistringImagePath = y.Crops_image,
                    Crops_name = y.Crops_name,
                    Crops_price = y.Crops_price,
                    Crop_Buying_End_Date = y.Crop_Buying_End_Date,
                    Crop_Buying_Staring_Date = y.Crop_Buying_Staring_Date,
                    MSPCrops_id = y.MSPCrops_id,
                    
                };
                allmspcrop.Add(crop);
            }
            return View(allmspcrop);
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
        public async Task<IActionResult> Create(addmspcrop addmspcrop)
        {
            if (ModelState.IsValid)
            {
                var seller_email = User.Identity.Name;

                String uniqefileName = null;
                if (addmspcrop.Crops_image != null)
                {
                    string uplodeFolder = Path.Combine(hostEnvironment.WebRootPath, "CropImage");
                    uniqefileName = Guid.NewGuid().ToString() + "_" + addmspcrop.Crops_image.FileName;
                    string filepath = Path.Combine(uplodeFolder, uniqefileName);
                    addmspcrop.Crops_image.CopyTo(new FileStream(filepath, FileMode.Create));
                }
               var crop = new MSPCropsDetail
                {
                   Crops_image=uniqefileName,
                   Crops_name=addmspcrop.Crops_name,
                   Crops_description=addmspcrop.Crops_description,
                   Crops_price=addmspcrop.Crops_price,
                   Crop_Buying_End_Date=addmspcrop.Crop_Buying_End_Date,
                   Crop_Buying_Staring_Date=addmspcrop.Crop_Buying_Staring_Date,
                  

                };
                _context.MSPCropsDetails.Add(crop);
                await _context.SaveChangesAsync();

                ViewBag.mes = "Your Crop is Added ";
                return View();
            }
            return View(addmspcrop);

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
            var crop = new editmspcrop
            {
                ExistringImagePath = mSPCropsDetail.Crops_image,
                Crops_name = mSPCropsDetail.Crops_name,
                Crops_description = mSPCropsDetail.Crops_description,
                Crops_price = mSPCropsDetail.Crops_price,
                Crop_Buying_End_Date = mSPCropsDetail.Crop_Buying_End_Date,
                Crop_Buying_Staring_Date = mSPCropsDetail.Crop_Buying_Staring_Date,
                MSPCrops_id=mSPCropsDetail.MSPCrops_id,

            };
            return View(crop);
        }

        // POST: MSPCropsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, editmspcrop editmspcrop)
        {
            if (id != editmspcrop.MSPCrops_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  
                    var curentcrop =await _context.MSPCropsDetails.Where(x => x.MSPCrops_id == id).FirstOrDefaultAsync();
                    curentcrop.Crops_description = editmspcrop.Crops_description;
                    curentcrop.Crops_name = editmspcrop.Crops_name;
                    curentcrop.Crops_price = editmspcrop.Crops_price;
                    curentcrop.Crop_Buying_End_Date = editmspcrop.Crop_Buying_End_Date;
                    curentcrop.Crop_Buying_Staring_Date = editmspcrop.Crop_Buying_Staring_Date;
                    if (editmspcrop.Crops_image != null)
                    {
                        string filepath = Path.Combine(hostEnvironment.WebRootPath,
                            "CropImage", editmspcrop.ExistringImagePath);
                        System.IO.File.Delete(filepath);
                        curentcrop.Crops_image = updateimage(editmspcrop);
                    }



                    _context.Update(curentcrop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MSPCropsDetailExists(editmspcrop.MSPCrops_id))
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
            return View(editmspcrop);
        }
        public string updateimage(editmspcrop editmspcrop)
        {
            string uniqname = null;
            if(editmspcrop.Crops_image!=null)
            {
                string uplodeFolder = Path.Combine(hostEnvironment.WebRootPath, "CropImage");
                uniqname = Guid.NewGuid().ToString() + "_" + editmspcrop.Crops_image.FileName;
                string filepath = Path.Combine(uplodeFolder, uniqname);
                editmspcrop.Crops_image.CopyTo(new FileStream(filepath, FileMode.Create));

            }
            return uniqname;
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
