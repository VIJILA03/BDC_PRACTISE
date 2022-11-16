using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Pages
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
