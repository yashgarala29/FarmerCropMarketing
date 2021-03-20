using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmerCropMarketing.Models;
using FarmerCropMarketing.Models.Context;
using FarmerCropMarketing.Models.viewmodel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using FarmerCropMarketing.Models.Class;
using Microsoft.AspNetCore.Authorization;

namespace FarmerCropMarketing.Controllers
{
    public class FarmersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public FarmersController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }
        
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> mymspsell()
        {
            var curetn_user =await _context.Farmers.Where(x => x.Farmers_email == User.Identity.Name).FirstOrDefaultAsync();
            var detail = await _context.MSPSellCrops.Include(x=>x.MSPCropsDetail).Where(x => x.Farmers_id == curetn_user.Farmers_id).ToListAsync();
            return View(detail);
        }
            [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> SellCropInMSP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSPCropsDetail = await _context.MSPCropsDetails.FindAsync(id);
            var farmerdetail= await _context.Farmers.Where(x=>x.Farmers_email==User.Identity.Name).FirstOrDefaultAsync();

            if (mSPCropsDetail == null || farmerdetail==null)
            {
                return NotFound();
            }
            var mspsellcrop = new MSPSellCrops
            {
                MSPCropsDetail = mSPCropsDetail,
                Farmers = farmerdetail,
            };
            
            return View(mspsellcrop);
        }

        [Authorize(Roles = "Farmer")]
        [HttpPost]
        public async Task<IActionResult> SellCropInMSP(int? id,MSPSellCrops mSPSellCrops)
        {
            
                if(mSPSellCrops.Crops_quantity==0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Crop Quentity");
                    return View(mSPSellCrops);
                }
                if(mSPSellCrops.Farmers.Farmers_address==null)
                {
                    ModelState.AddModelError(string.Empty, "Address is Required Field");
                    return View(mSPSellCrops);
                }
                if(id==null || id==0)
            {
                return NotFound();
            }
            var mSPCropsDetail = await _context.MSPCropsDetails.FindAsync(id);
          
            
            var curentuser = await _context.Farmers.Where(x => x.Farmers_email == User.Identity.Name).FirstOrDefaultAsync();
            if (mSPCropsDetail == null || curentuser == null)
            {
                return NotFound();
            }
            curentuser.Farmers_address = mSPSellCrops.Farmers.Farmers_address;
                _context.Update(curentuser);
                var sellcrop = new MSPSellCrops
                {
                    Crops_quantity = mSPSellCrops.Crops_quantity,
                    MSPCrops_id = mSPCropsDetail.MSPCrops_id,
                    Farmers_id = curentuser.Farmers_id,

                };
                _context.Add(sellcrop);
                await _context.SaveChangesAsync();

               return  RedirectToAction("sellinmsp", "Farmers");
            
        }



        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> sellinmsp()
        {
            var maspcrop = await _context.MSPCropsDetails.Where(x => x.Crop_Buying_Staring_Date <= DateTime.Now && x.Crop_Buying_End_Date >= DateTime.Now).ToListAsync();

            return View(maspcrop);
        }
        //[Authorize(Roles = "Farmer")]
        public async Task<IActionResult> HomepageFarmer()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("HomePageAdmin", "Admin");
            }
            else if (User.IsInRole("Government"))
            {
                return RedirectToAction("homePageGovernment", "Government");
            }
            return View(await _context.Crops.ToListAsync());
        }
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> MyCart()
        {
            var cart_crop = _context.Cart.Include(x => x.Farmers).Include(x => x.Crops).Where(x => x.Farmers.Farmers_email == User.Identity.Name);
            return View(cart_crop);
        }

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> mybuyitem()
        {
            var curentuser = User.Identity.Name;
            var curentuserid = _context.Farmers.Where(x => x.Farmers_email == curentuser).FirstOrDefault().Farmers_id;
            var buyitemlist = await _context.Orders.Include(x => x.Farmers).Include(x => x.Crops).Where(x => x.Farmers_id == curentuserid && x.ordertype == "Buy").ToListAsync();
            return View(buyitemlist);
        }

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> addtocart(int id)
        {
            if(id==null)
            {
                return NotFound();
            }
            
            var curentuser = User.Identity.Name;
            var curentfarmer = _context.Farmers.Where(x => x.Farmers_email == curentuser).FirstOrDefault();

            var crop_cart = _context.Crops.Where(x => x.Crops_id == id).FirstOrDefault();
            if (crop_cart==null)
            {
                return NotFound();
            }
            var cart_data = new Cart
            {
                Crops_id = crop_cart.Crops_id,
                Farmers_id = curentfarmer.Farmers_id,
            };
            _context.Add(cart_data);
            await _context.SaveChangesAsync();
            return RedirectToAction("HomepageFarmer", "Farmers");

        }

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> mysellitem()
        {
            var curentuser = User.Identity.Name;
            var curentuserid = _context.Farmers.Where(x => x.Farmers_email == curentuser).FirstOrDefault().Farmers_id;
            var buyitemlist = await _context.Orders.Include(x => x.Farmers).Include(x => x.Crops).Where(x => x.seller_id == curentuserid && x.ordertype=="Sell").ToListAsync();
            return View(buyitemlist);
            
        }
        [HttpGet]

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Buy(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var curentuser = await _context.Farmers.Where(x => x.Farmers_email == User.Identity.Name).FirstOrDefaultAsync();
            var selleruser = await _context.Crops.Include(x => x.Farmers).Where(x => x.Crops_id == id).FirstOrDefaultAsync();
            if (selleruser.itComplited)
            {
                return RedirectToAction("HomepageFarmer", "Farmers");
            }
            var newOrder = new Orders
            {
                delivery_date = DateTime.Now,
                Crops_id = id,
                order_date = DateTime.Now,
                seller_id = selleruser.Farmers_id,
                Farmers_id = curentuser.Farmers_id,
                order_status = "success",
                total_pricer = selleruser.Crops_price,
                ordertype="Buy",
            };
            selleruser.itComplited = true;
            _context.Crops.Update(selleruser);
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("mybuyitem");
        }


        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Sell(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var curentuser =await _context.Farmers.Where(x => x.Farmers_email == User.Identity.Name).FirstOrDefaultAsync();
            var buyyeruser = await _context.Crops.Include(x => x.Farmers).Where(x => x.Crops_id == id).FirstOrDefaultAsync();
            if(buyyeruser.itComplited)
            {
                  return RedirectToAction("HomepageFarmer", "Farmers");
            }
            var newOrder = new Orders
            {
                delivery_date=DateTime.Now,
                Crops_id=id,
                order_date=DateTime.Now,
                seller_id= curentuser.Farmers_id,
                Farmers_id= buyyeruser.Farmers_id ,
                order_status= "success",
                total_pricer=buyyeruser.Crops_price,
                ordertype="Sell",
            };
            buyyeruser.itComplited = true;
            _context.Crops.Update(buyyeruser);
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("mysellitem");
        }

        [HttpGet]

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> AddNewCrop()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> AddNewCrop(int? id,addnewCrop addnewCrop)
        {
          
            if (ModelState.IsValid)
            {
                var seller_email = User.Identity.Name;
                
                String uniqefileName = null;
                if (addnewCrop.crop_image != null)
                {
                    string uplodeFolder = Path.Combine(hostEnvironment.WebRootPath, "CropImage");
                    uniqefileName = Guid.NewGuid().ToString() + "_" + addnewCrop.crop_image.FileName;
                    string filepath = Path.Combine(uplodeFolder, uniqefileName);
                    addnewCrop.crop_image.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                Crops crop = new Crops
                {
                    buyOrsell=addnewCrop.youwanttosell,
                    Crops_description=addnewCrop.crop_description,
                    Crops_image= uniqefileName,
                    Crops_price=addnewCrop.crop_price,
                    Crops_name=addnewCrop.crop_name,
                    Crops_quantity=addnewCrop.crop_quantity,
                    Farmers_id= _context.Farmers.Where(x=>x.Farmers_email==seller_email).FirstOrDefault().Farmers_id,
                    itComplited=false,
                    
                    
                };
                _context.Crops.Add(crop);
                await _context.SaveChangesAsync();

                return RedirectToAction("HomepageFarmer", "Farmers");
            }
            return View(addnewCrop);

        }

        [Authorize(Roles = "Farmer")]
        // GET: Farmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmers.ToListAsync());
        }

        [Authorize(Roles = "Farmer")]
        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.Farmers
                .FirstOrDefaultAsync(m => m.Farmers_id == id);
            if (farmers == null)
            {
                return NotFound();
            }

            return View(farmers);
        }

        // GET: Farmers/Create
        [Authorize(Roles = "Farmer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Create([Bind("Farmers_id,Farmers_name,Farmers_email,Farmers_mobile_no,Farmers_address,Farmers_image")] Farmers farmers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmers);
        }

        // GET: Farmers/Edit/5
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.Farmers.FindAsync(id);
            if (farmers == null)
            {
                return NotFound();
            }
            return View(farmers);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Edit(int id, [Bind("Farmers_id,Farmers_name,Farmers_email,Farmers_mobile_no,Farmers_address,Farmers_image")] Farmers farmers)
        {
            if (id != farmers.Farmers_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmersExists(farmers.Farmers_id))
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
            return View(farmers);
        }

        // GET: Farmers/Delete/5
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.Farmers
                .FirstOrDefaultAsync(m => m.Farmers_id == id);
            if (farmers == null)
            {
                return NotFound();
            }

            return View(farmers);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmers = await _context.Farmers.FindAsync(id);
            _context.Farmers.Remove(farmers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmersExists(int id)
        {
            return _context.Farmers.Any(e => e.Farmers_id == id);
        }
    }
}
