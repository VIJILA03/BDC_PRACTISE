using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lms.Pages
{
    public class returnbookuserModel : PageModel
    {
        public string name1;
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            DateTime issuedate = Convert.ToDateTime(Request.Query["issuedate"]);
            string formatted = issuedate.ToString("yyyy/MM/dd HH:mm:ss");
            DateTime returndate = Convert.ToDateTime(Request.Query["returndate"]);
            string formatted1 = returndate.ToString("yyyy/MM/dd HH:mm:ss");
            if (HttpContext.Session.GetString("Name") != null)
            {
                name1 = HttpContext.Session.GetString("Name");
            }
        }
    }
}
