using lms.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace lms.Pages
{
    public class userlogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser>SignInManager;

        public userlogoutModel(SignInManager<ApplicationUser> SignInManager)
        {
            this.SignInManager = SignInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await SignInManager.SignOutAsync();
            return RedirectToPage("userlogin");
        }
        public IActionResult OnPostDontLogoutAsync()
        {
            return RedirectToPage("Index");
        }
    }
}
