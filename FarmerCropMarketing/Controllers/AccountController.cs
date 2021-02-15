
using FarmerCropMarketing.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password,true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
            [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email

                };
                IdentityResult identityResult = null;
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if(result.Succeeded)
                {
                    var s = userManager.Users.Where(a => a.Email == registerViewModel.Email).FirstOrDefault();
                    identityResult = await userManager.AddToRoleAsync(s, "Farmer");
                    if (identityResult.Succeeded)
                        return RedirectToAction("index", "home");
                }
            }
            return View(registerViewModel);
        }
        //--------------For Goverment------------------------------------
        [HttpGet]
        public IActionResult GovermentLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GovermentLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult GovermentRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GovermentRegister(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email

                };
                IdentityResult identityResult = null;
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    var s = userManager.Users.Where(a => a.Email == registerViewModel.Email).FirstOrDefault();
                    identityResult = await userManager.AddToRoleAsync(s, "Government");
                    if (identityResult.Succeeded)
                        return RedirectToAction("index", "home");
                }
            }
            return View(registerViewModel);
        }
        //------------------------------For Admin------------------------------
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegister(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email

                };
                IdentityResult identityResult = null;
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    var s=userManager.Users.Where(a=>a.UserName==registerViewModel.Email).FirstOrDefault();
                    identityResult=await userManager.AddToRoleAsync(s, "Admin");
                    if(identityResult.Succeeded)
                        return RedirectToAction("index", "home");
                
                }
            }
            return View(registerViewModel);
        }
        //----------------Logout-----------------
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("privacy", "home");
                
        }
        




    }
}
