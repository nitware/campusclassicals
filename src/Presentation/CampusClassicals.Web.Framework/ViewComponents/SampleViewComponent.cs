using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CampusClassicals.Web.Framework.ViewComponents
{
    public class SampleViewComponent : ViewComponent
    {
        public string ReturnUrl { get; set; } = "/";

        public IViewComponentResult Invoke()
        {
            string[] categories = new string[] {
               "Football",
               "Apparel",
               "Shoes",
               "Books",
               "Music",
               "Videos",
            };
            
            return View(categories);
        }
        
        //public string Invoke()
        //{
        //    return "Hello from the Nav View Component";
        //}
    }




}
