using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using CampusClassicals.Domain;
using Microsoft.AspNetCore.Identity;
using CampusClassicals.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace CampusClassicals.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() => View(_userManager.Users);

        public async Task<IActionResult> SignOut()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home", null);
        }





    }
}
