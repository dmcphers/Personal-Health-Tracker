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
            RedirectUserWhenAlreadyLogginIn();
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

                if(result.Succeeded) // new user was created
                {

                    // assign the selected role to the newly created user
                    if(vm.Email == "admin@abc.com")
                    {
                        result = await _userManager.AddToRoleAsync(newUser, "Admin");
                    }
                    else
                    {
                        result = await _userManager.AddToRoleAsync(newUser, "User");
                    }
                   

                    if(result.Succeeded)
                    {
                        // we can login the user
                        await _signInManager.SignInAsync(newUser, false);
                        
                        // redirect
                        if(vm.Email == "admin@abc.com")
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        return RedirectToAction("Index", "User");

                    }
                    
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

        [HttpGet]
        public IActionResult Login()
        {
            RedirectUserWhenAlreadyLogginIn();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if(ModelState.IsValid)
            {
               var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password incorrrect");
                }
            }

            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectUserWhenAlreadyLogginIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return null;
        }
    }
}