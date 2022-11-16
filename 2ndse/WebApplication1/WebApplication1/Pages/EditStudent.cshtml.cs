using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace WebApplication1.Pages
{
    public class EditStudentModel : PageModel
    {

        public CreateStudent crtstd = new CreateStudent();
        public string ErrorMsg = "";
        public string SucceedMsg = "";
        public void OnGet()
        {
            string name = Request.Query["Name"];
        }
        public void OnPost()
        {
            crtstd.Name = Request.Form["Name"];
            if (Request.Form["Marks"].ToString().Length != 0)
            {
                crtstd.Marks = Convert.ToInt32(Request.Form["Marks"]);
            }
            crtstd.CourseName = Request.Form["CourseName"];
            if (crtstd.Name.Length == 0 || crtstd.Marks == 0 || crtstd.CourseName.Length == 0)
            {
                ErrorMsg = "All fields are required";
                return;
            }
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "insert into StudentExam values(@StdName,@Marks,@CourseName)";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@StdName", crtstd.Name);
                    cmd.Parameters.AddWithValue("@Marks", crtstd.Marks);
                    cmd.Parameters.AddWithValue("@CourseName", crtstd.CourseName);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
            }
            crtstd.Name = "";
            crtstd.Marks = 0;
            crtstd.CourseName = "";
            SucceedMsg = "New student is added successfully";
            Response.Redirect("/createstd");
        }

        public class CreateStudent
        {
            public string Name;
            public int Marks;
            public string CourseName;
        }

    }
}



