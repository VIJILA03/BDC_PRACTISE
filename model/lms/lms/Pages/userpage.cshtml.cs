using lms.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lms.Pages
{
    public class userpageModel : PageModel
    {
        public string name;
       public void OnGet()
        {
            if(HttpContext.Session.GetString("Name")!=null)
                {
                name = HttpContext.Session.GetString("Name");
            }
          // string UserName = Request.Query["name"];
        }
    }
}
