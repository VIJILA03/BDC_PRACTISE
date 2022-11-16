using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lms.Pages
{
    public class delbookModel : PageModel
    {
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
        }
    }
}
