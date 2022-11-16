using Microsoft.AspNetCore.Mvc;
using lms.viewmodels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using lms.model;

namespace lms.Pages
{
    
    public class userloginModel : PageModel
    {

        string name;
        [BindProperty]
        public login Model { get; set; }
        public string ErrorMsg = "";
        private readonly SignInManager<ApplicationUser> SignInManager;
       

        public userloginModel(SignInManager<ApplicationUser> SignInManager)
        {
            this.SignInManager = SignInManager;
        }


        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync(string returnurl = null)
        {
           name = Request.Form["Model.Email"];
            Console.WriteLine(name);
            Console.WriteLine("before vaidation");
            Console.WriteLine(Model.Email);
            Console.WriteLine(Model.Password);
            HttpContext.Session.SetString("Name", name);
           
            if (Model.Email!=null && Model.Password!=null)
            {
                Console.WriteLine("after vaidation");
                var identityResult = await SignInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.Rememberme, false);
                if (identityResult.Succeeded)
                {
                    if (returnurl == null || returnurl == "/")
                    {
                                                                                                                                         
                        TempData["UserName"] = Model.Email;
                     return RedirectToPage("userpage");
                    }
                    else
                    {
                        return RedirectToPage(returnurl);
                    }
                }
                ErrorMsg= "User name or Password incorrect";

            }
            
            return Page();
        }
    }
}
