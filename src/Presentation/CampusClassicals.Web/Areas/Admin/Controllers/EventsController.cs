using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampusClassicals.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
        public EventsController()
        {

        }

        public async Task<IActionResult> Index() => await Task.FromResult(View());
       

    }
}
