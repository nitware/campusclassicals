﻿
using CampusClassicals.Domain;
using CampusClassicals.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampusClassicals.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signinManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            LoginModel loginModel = new LoginModel() { ReturnUrl = returnUrl };
            
            return await Task.FromResult(View(loginModel));
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    await _signinManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await _signinManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(loginModel.ReturnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(loginModel.Email), "Email or password is invalid!");
            }
           
            return View(loginModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register() => await Task.FromResult(View());

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Name = model.Name, Email = model.Email, UserName = model.Email };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //return RedirectToAction(nameof(Outcome));

                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        //[AllowAnonymous]
        //public async Task<IActionResult> Outcome() => await Task.FromResult(View());



    }
}
