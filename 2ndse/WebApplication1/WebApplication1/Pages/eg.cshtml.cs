using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Text.Encodings.Web;
namespace WebApplication1.Pages
{
    public class egModel : PageModel
    {
        public CreateStudent crtstd = new CreateStudent();
        public string ErrorMsg = "";
        public string SucceedMsg = "";

        public void OnGet()
        {
        }
        public void OnPost()
        {

            crtstd.name = Request.Form["Name"];
            if (Request.Form["Marks"].ToString().Length != 0)
            {
                crtstd.mark = Convert.ToInt32(Request.Form["Marks"]);
            }
            crtstd.course = Request.Form["CourseName"];
            if (crtstd.name.Length == 0 || crtstd.mark == 0 || crtstd.course.Length == 0)
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
                    cmd.Parameters.AddWithValue("@StdName", crtstd.name);
                    cmd.Parameters.AddWithValue("@Marks", crtstd.mark);
                    cmd.Parameters.AddWithValue("@CourseName", crtstd.course);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
            }
            crtstd.name = "";
            crtstd.mark = 0;
            crtstd.course = "";
            SucceedMsg = "New student is added successfully";
            Response.Redirect("/createstd");
        }

        public class CreateStudent
        {
            public string name;
            public int mark;
            public string course;
        }

    }
}

