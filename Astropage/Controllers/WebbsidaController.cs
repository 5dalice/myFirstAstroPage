using Astropage.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Astropage.Controllers
{
    public class WebbsidaController : Controller
    {
        //  returnerar en vy för startsidan
        public IActionResult Index(string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //  returnerar en vy för månadens horoskop
        public IActionResult Monthly()
        {
            return View();
        }

        // returnerar en vy för dagens horoskop
        public IActionResult Todays()
        {
            return View();
        }

        //  hämtar data från databasen och returnerar en vy med dessa
        public IActionResult Signs()
        {
            using (astroContext db = new astroContext())
            {
                List<astro>
    tecken = db.Astro.ToList();
                return View(tecken);
            }
        }

        // returnerar en vy där användaren kan lägga till namn + datum
        public IActionResult LäggaTill()
        {
            return View();
        }

        [HttpPost]
        // POST som lägger till namn+datum i databasen sen return till signs
        public IActionResult LäggaTill(astro userdata)
        {
            using (astroContext info = new astroContext())
            {
                info.Astro.Add(userdata);
                info.SaveChanges();
            }
            return RedirectToAction("Signs");
        }

        //  inloggning, returnerar en vy.
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>
            Inloggad(string returnUrl = "")
        {
            string userName = Request.Form["Name"];
            string password = Request.Form["Id"];

            // Kontrollera användarnamn och lösenord
            bool userOk = CheckUser(userName, password);

            if (userOk)
            {
                // Allt stämmer, logga in användaren
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

                // Skicka användaren vidare till returnUrl om den finns annars till startsidan
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Inloggad", "Webbsida");
            }

          //  ViewBag.ErrorMessage = "Inloggningen inte godkänd";
            ViewData["ReturnUrl"] = returnUrl;

            return RedirectToAction("Index"); 
        }

        private bool CheckUser(string userName, string password)
        {
            if (userName == "Alice" && password == "Hemlig")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // returnera vy för adminsida
        [Authorize]
        public IActionResult inloggad()
        {
            return View();
        }

    }
}
