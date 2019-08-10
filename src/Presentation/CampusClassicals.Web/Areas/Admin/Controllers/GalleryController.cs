using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace CampusClassicals.Web.Areas.Media.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        public GalleryController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
