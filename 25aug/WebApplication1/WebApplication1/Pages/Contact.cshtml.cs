using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class ContactModel : PageModel
    {
        public string fname = "", lname = "", msg = "";
        public bool hasinfo = false;
        public int mcount = 0;
        public void OnGet()
        {

        }
        public void OnPost()
        {
            hasinfo = true;
            mcount++;
            fname = Request.Form["FirstName"];
            lname = Request.Form["LastName"];
            msg = Request.Form["Message"];
            fname = fname + lname;
            msg = "Thank for the message:" + msg +"your message number is"+ mcount;
        }

    }
}
