using lms.model;
using lms.viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class userregModel : PageModel
    {
        //string name;
        [BindProperty]
        public Register Model { get; set; }
        

        private readonly UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManger;
       
        public userregModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManger = signInManager;

        }
       
        public void OnGet()
        {

        }
        public async Task<ActionResult> OnPostAsync()
        {
            //name = Request.Form["Model.Email"];
            //HttpContext.Session.SetString("Name", name);

            if (ModelState.IsValid)
            {

             var user = new ApplicationUser() { 
                 UserName = Model.Email, 
                 Email = Model.Email, 
                 PhoneNumber = Model.PhoneNumber,
                 LastName = Model.LastName,
                 FirstName = Model.FirstName,
                 
             };
             var result= await  userManager.CreateAsync(user, Model.Password);
                if(result.Succeeded)
                {
                    await signInManger.SignInAsync(user, false);

                    try
                    {
                        string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                        SqlConnection sqlconn = new SqlConnection(connectionstring);
                        sqlconn.Open();
                        string QueryString = "insert into lms.dbo.UserInfo(FirstName,LastName,UserName,Email,PhoneNumber,Password) values(@FirstName,@LastName,@UserName,@Email,@PhoneNumber,@Password)";
                        Console.WriteLine(QueryString);
                        using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                        {
                            cmd.Parameters.AddWithValue("@FirstName", Model.FirstName);
                            cmd.Parameters.AddWithValue("@LastName", Model.LastName);
                            cmd.Parameters.AddWithValue("@UserName",Model.Email);
                            cmd.Parameters.AddWithValue("@Email", Model.Email);
                            cmd.Parameters.AddWithValue("@PhoneNumber", Model.PhoneNumber);
                            cmd.Parameters.AddWithValue("@Password",Model.Password);
                            Console.WriteLine(QueryString);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                

                    return Redirect("userpage");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }
    }
}