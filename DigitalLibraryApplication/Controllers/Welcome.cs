using Microsoft.AspNetCore.Mvc;

namespace DigitalLibraryApplication.Controllers
{
    public class Welcome : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the digital library";
            return View();
        }

        public string Description()
        {
            return "This is the app for managing digital books";
        }
    }
}
