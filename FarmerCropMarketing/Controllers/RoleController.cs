using FarmerCropMarketing.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        //[HttpGet]
        //public IActionResult UserRole()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult UserRole()
        {
            ViewBag.CurrentRole = "Faculty";

            var user_model = new List<UserRoleViewModel>();
            //SelectList selectListItems=new SelectList()
            foreach (var user in userManager.Users)
            {
                var userviewrolemodel = new UserRoleViewModel
                {
                    Email = user.Email,
                    UserId = user.Id
                };
                //IList<string> role= await  userManager.GetRolesAsync(user);
                //if(role[0]==null)
                //{

                //}
                user_model.Add(userviewrolemodel);

            }
            return View(user_model);
        }

        //[HttpPost]
        //public async Task<IActionResult> UserRole(UserRoleViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
                
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("index", "home");
        //        }
        //        foreach (IdentityError error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }
        //    return View(model);
        //}


    }
}
