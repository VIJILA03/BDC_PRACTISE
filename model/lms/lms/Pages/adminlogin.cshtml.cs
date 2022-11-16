using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lms.Pages
{
    public class adminloginModel : PageModel
    {
       
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg = "";

        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (UserName.Equals("ADMIN") && Password.Equals("admin"))
            {
                
                Response.Redirect("/admin");
              
            }
            else
            {
                Msg = "Invalid Credentails check your UserName and Password";
                
            }
        }
    }
}
