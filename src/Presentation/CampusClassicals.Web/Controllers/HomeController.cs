using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

namespace CampusClassicals.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var @event = 7;
            @event += 9;

            _logger.LogInformation("Index action has started!");

            return View();
        }

        //[Microsoft.AspNetCore.Authorization.Authorize(Policy = "")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            string s = "";
            var names = new[] { "Kayak", "Lifejacket", "Soccer ball" };

            var products = new[] {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
            };
            
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int? id)
        {
            return View();
        }



    }
}
