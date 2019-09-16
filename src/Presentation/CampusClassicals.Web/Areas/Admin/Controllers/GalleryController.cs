using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CampusClassicals.Domain;
using CampusClassicals.Core.Data;
using CampusClassicals.Core.Infrastructure;

namespace CampusClassicals.Web.Areas.Media.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly IRepository<Gallery> _galleryRepository;

        public GalleryController(IRepository<Gallery> galleryRepository)
        {
            Guard.NotNull(galleryRepository, nameof(galleryRepository));

            _galleryRepository = galleryRepository;
        }
                
        public async Task<IActionResult> Index()
        {
            //List<Gallery> galleries = await _galleryRepository.GetAllAsync(x => x.OrderByDescending(g => g.DisplayOrder));

            List<Gallery> galleries = await _galleryRepository.GetAllAsync(x => x.OrderByDescending(g => g.CreatedOn));
            return View(galleries);
        }

       


    }
}
