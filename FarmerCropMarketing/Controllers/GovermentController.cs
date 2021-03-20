using FarmerCropMarketing.Models.Class;
using FarmerCropMarketing.Models.Context;
using FarmerCropMarketing.Models.viewmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Controllers
{
    public class GovernmentController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly AppDbContext _context;

        public GovernmentController(UserManager<IdentityUser> userManager,
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
        public IActionResult homepageGovernment()
        {
            return View();
        }
      
        
    }
}
