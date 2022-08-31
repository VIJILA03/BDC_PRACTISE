using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TempCheck.Pages
{
    public class TempCheckModel : PageModel
    {
        public int temp = 0;
        public bool hasinfo = false;
        public string msg = "";

        public void OnGet()
        {

        }



        public void OnPost()
        {

            hasinfo = true;
            temp = int.Parse(Request.Form["Temperature"]);
            if (temp > 96 && temp <= 99)
                msg = "NORMAL";
            else if (temp > 99 && temp <= 101)
                msg = "TAKE HOME CARE";
            else if (temp > 101)
                msg = "NEED MEDICAL ATTENTION";
        

        }

    }

    }
 
    

