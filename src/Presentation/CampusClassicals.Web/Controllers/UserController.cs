
using CampusClassicals.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampusClassicals.Web.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {

        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            return View();
        }

    }
}
