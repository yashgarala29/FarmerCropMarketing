
using FarmerCropMarketing.Models;
using FarmerCropMarketing.Models.Context;
using FarmerCropMarketing.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext _context;

        public AdminController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _context = context;
        }
        public IActionResult HomePageAdmin()
        {
            return View();
        }
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmers = await _context.Farmers.FindAsync(id);
            _context.Farmers.Remove(farmers);
            var user = await userManager.FindByEmailAsync(farmers.Farmers_email);
            IdentityResult result = await userManager.DeleteAsync(user);


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool FarmersExists(int id)
        {
            return _context.Farmers.Any(e => e.Farmers_id == id);
        }

        public async Task<IActionResult> UserList()
        {
            var all_farmer = await userManager.GetUsersInRoleAsync("Farmer");
            List<Farmers> farmers = new List<Farmers>();
            foreach(var i in all_farmer)
            {
                var userlist = await _context.Farmers.Where(x=>x.Farmers_email==i.UserName).FirstOrDefaultAsync();
                farmers.Add(userlist);

            }
            return View(farmers);
            
        }
        [HttpGet]
        public async Task<IActionResult> ListOfAllUser()
        {
            var userlist = userManager.Users.ToList();
            var rolelist = roleManager.Roles.ToList();
            var user_role_list = new List<UserRoleViewModel>();
            for(int i=0;i<userlist.Count;i++)
            {
                var usermanager=(await userManager.GetRolesAsync(userlist[i])).FirstOrDefault();
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = userlist[i].Id,
                    Email = userlist[i].Email,
                    //RoleName=rolelist.Where(a=>a.Id==usermanager).FirstOrDefault().Id,
                    RoleId = usermanager,
                    
                };
                userRoleViewModel.Role = rolelist;
                user_role_list.Add(userRoleViewModel);
            }
            return View(user_role_list);
        }
        [HttpGet]
        public async Task<IActionResult> CropList()
        {
            //var x=_context.Cart.Include(c => c.Crops).Include(c => c.Farmers);
            var croplist =await _context.Crops.Include(x => x.Farmers).Where(x => x.itComplited == false).ToListAsync();
            return View(croplist);
        }
        //[HttpPost]
        //public IActionResult ListOfAllUser()
        //{
        //    return View();
        //}
    }
}
