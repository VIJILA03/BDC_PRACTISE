using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class deleteempModel : PageModel
    {
        public void OnGet()
        {
            
            int id = Convert.ToInt32(Request.Query["id"]);
        }
    }
}
