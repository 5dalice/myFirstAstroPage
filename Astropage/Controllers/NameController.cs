using Astropage.Models;
using Microsoft.AspNetCore.Mvc;
using Astropage.Models;

namespace test1.Controllers
{
    public class NameController : Controller
    {
        public IActionResult Signs()
        {

            using (astroContext db = new astroContext())
            {
                List<astro> Astro = db.Astro.ToList();


                return View(Astro);
            }

        }
    }
}
