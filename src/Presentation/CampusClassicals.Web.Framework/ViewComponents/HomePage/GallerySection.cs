using CampusClassicals.Core.Data;
using CampusClassicals.Core.Infrastructure;
using CampusClassicals.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CampusClassicals.Web.Framework.ViewComponents.HomePage
{
    public class GallerySection : ViewComponent
    {
        private readonly IRepository<Gallery> _galleryRepository;

        public GallerySection(IRepository<Gallery> galleryRepository)
        {
            Guard.NotNull(galleryRepository, nameof(galleryRepository));

            _galleryRepository = galleryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Gallery> galleries = await _galleryRepository.GetAllAsync(x => x.OrderByDescending(g => g.CreatedOn));
            return View("/Views/Home/Components/HomePage/_Gallery.cshtml", galleries);
        }

        //public IViewComponentResult Invoke()
        //{
        //    List<Gallery> galleries = _galleryRepository.GetAll(x => x.OrderByDescending(g => g.CreatedOn));
        //    return View("/Views/Home/Components/HomePage/_Gallery.cshtml", galleries);
        //}

    }
}
