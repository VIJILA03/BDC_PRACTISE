using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace lms.Pages
{
    public class mindateModel : PageModel
    {


        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["Id"]);


        }


    }
}




