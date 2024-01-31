using Microsoft.AspNetCore.Mvc;

namespace Astropage.Controllers
{
    public class Homecontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
