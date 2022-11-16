using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Data.SqlClient;
namespace lms.Pages
{
    public class returnbookModel : PageModel
    {


       
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            string username = Request.Query["username"];
            DateTime issuedate = Convert.ToDateTime(Request.Query["issuedate"]);
            string formatted = issuedate.ToString("yyyy/MM/dd HH:mm:ss");
            DateTime returndate = Convert.ToDateTime(Request.Query["returndate"]);
            string formatted1 = returndate.ToString("yyyy/MM/dd HH:mm:ss");


        }

    }

}



