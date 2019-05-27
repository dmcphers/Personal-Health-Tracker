using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalHealthTracker.Controllers;
using PersonalHealthTracker.Domain.Model;
using PersonalHealthTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace PersonalHealthTracker.WebUI.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]

        public IActionResult Register()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser
                {
                    UserName = vm.Email, // email
                    NormalizedUserName = vm.Email.ToUpper(),
                    Email = vm.Email,
                    NormalizedEmail = vm.Email.ToUpper()
                };

                var result = await _userManager.CreateAsync(newUser, vm.Password);

                if(result.Succeeded)
                {
                    // new user was created
                    // we can login the user
                    await _signInManager.SignInAsync(newUser, false);
                    // send user to the right page (redirect)
                    return RedirectToAction("Index", "Home"); // /home/index
                }
                else
                {
                    // new user was not added
                   foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            // sending back the error(s) to the view (register form)
            return View(vm);
        }
    }
}