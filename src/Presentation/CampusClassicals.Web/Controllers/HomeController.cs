using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using CampusClassicals.Domain;
using CampusClassicals.Core.Data;
using CampusClassicals.Core.Infrastructure;

namespace CampusClassicals.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Gallery> _galleryRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Gallery> galleryRepository)
        {
            Guard.NotNull(galleryRepository, nameof(galleryRepository));

            _galleryRepository = galleryRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index() => await Task.FromResult(View());
        
       
        //[Microsoft.AspNetCore.Authorization.Authorize(Policy = "")]
        //[Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            //string s = "";
            //var names = new[] { "Kayak", "Lifejacket", "Soccer ball" };

            //var products = new[] {
            //    new { Name = "Kayak", Price = 275M },
            //    new { Name = "Lifejacket", Price = 48.95M },
            //    new { Name = "Soccer ball", Price = 19.50M },
            //    new { Name = "Corner flag", Price = 34.95M }
            //};
            
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
