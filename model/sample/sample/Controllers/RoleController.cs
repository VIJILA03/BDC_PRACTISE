using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sample.Controllers
{
    public class RoleController : Controller
    {
  


        public IActionResult Index()
        {
            return View();
        }
        // [Authorize(Policy = "RequireManager")]
        [Authorize(Roles = "User,Administrator")]
        public IActionResult Manager()
        {
            return View();
        }


        //[Authorize(Policy = "RequireAdmin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}

