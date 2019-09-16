using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CampusClassicals.Web.Framework.ViewComponents.HomePage
{
    public class SampleSection : ViewComponent
    {
        public string ReturnUrl { get; set; } = "/";

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string[] categories = new string[] {
               "Football",
               "Apparel",
               "Shoes",
               "Books",
               "Music",
               "Videos",
            };

            return await Task.FromResult( View("/Views/Home/Components/HomePage/Sax.cshtml", categories));

            //return View("Sax", categories);
        }
        
        //public string Invoke()
        //{
        //    return "Hello from the Nav View Component";
        //}
    }




}
