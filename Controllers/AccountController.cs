using EmployeeMangement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Controllers
{
    public class AccountController : Controller
    {
        //VEDIEO 67 STEP2 cretae constructo//
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;  // Use 'this' to distinguish between the field and parameter
            this.signInManager = signInManager;
        }

        //VEDIEO 67 STEP2 cretae constructo CLOSE//

        //public UserManager<IdentityUser> UserManager { get; }

        //VEDIEO 67 STEP2 cretae constructo//

        //vedieo 69 create logout//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //close 69//
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()// change index Register
        {
            return View();
        }

        //vedioe 67 1 ASP.NET CORE USERMANAGER AND SIGNED MANAGER
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrationViewModel model)// change index Register
        {
            if (ModelState.IsValid)
            {
                   var user = new IdentityUser { 
                    UserName = model.Email, 
                    Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }


        //vedioe 70 1 ASP.NET CORE Login Functionality//
        [HttpGet]
        [AllowAnonymous]// vedioe 71
    public IActionResult Login()// change index Register
    {
        return View();
    }

    //vedioe 70 1 ASP.NET CORE Login Functionality//
    [HttpPost]
        [AllowAnonymous]//vedieo 71
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)// change index Register// and returnurl see72 vedieo adding code 
    {
        if (ModelState.IsValid)
        {

             var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                    // 72 return url//
                    if(!string.IsNullOrEmpty(ReturnUrl))
                    {
                        //return LocalRedirect(ReturnUrl);//73 vedieo valunaribily//
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //
                ////await signInManager.SignInAsync(user, isPersistent: false);
                //return RedirectToAction("Index", "Home");
               
            }
            
                ModelState.AddModelError(string.Empty,"Invalid Login Attempt");
            }       
        return View(model);
    }
}
}
//vedioe close 70 1 ASP.NET CORE Login Functionality//
