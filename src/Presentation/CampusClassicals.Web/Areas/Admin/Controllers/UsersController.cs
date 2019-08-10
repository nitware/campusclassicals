using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using CampusClassicals.Domain;
using Microsoft.AspNetCore.Identity;
using CampusClassicals.Web.Models;

namespace CampusClassicals.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users);
       
        public async Task<IActionResult> Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Email = model.Email, UserName = model.Username };
                
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
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





    }
}
