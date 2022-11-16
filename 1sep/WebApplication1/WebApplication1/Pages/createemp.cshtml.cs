using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace WebApplication1.Pages
{
    public class createempModel : PageModel
    {
        public addemp addemp = new addemp();
        public string ErrorMsg = "";
        public string SucceedMsg = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            
                addemp.id = Convert.ToInt32(Request.Form["Id"]);
            
            addemp.name = Request.Form["Name"];
            addemp.designation = Request.Form["Designation"];
            if (Request.Form["Dob"].ToString().Length != 0)
            {
                addemp.dob = Convert.ToDateTime(Request.Form["Dob"]);
            }
            if (Request.Form["Doj"].ToString().Length != 0)
            {
                addemp.doj = Convert.ToDateTime(Request.Form["Doj"]);
            }
            addemp.loc = Request.Form["BaseLocation"];
            if (addemp.id == 0 || addemp.name.Length == 0 || addemp.designation.Length == 0||addemp.loc.Length==0||
                addemp.dob.ToString().Length==0|| addemp.doj.ToString().Length == 0||addemp.dob==DateTime.MinValue||addemp.doj==DateTime.MinValue)
            {
                ErrorMsg = "All fields are required";
                return;
            }
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "insert into Empinfo values(@EmpId,@EmpName,@Designation,@DOB,@DOJ,@BaseLocation)";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", addemp.id);
                    cmd.Parameters.AddWithValue("@EmpName", addemp.name);
                    cmd.Parameters.AddWithValue("@Designation", addemp.designation);
                    cmd.Parameters.AddWithValue("@DOB", addemp.dob);
                    cmd.Parameters.AddWithValue("@DOJ", addemp.doj);
                    cmd.Parameters.AddWithValue("@BaseLocation", addemp.loc);
                    cmd.ExecuteNonQuery();
                }

            }
           
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            addemp.id = 0;
            addemp.name = "";
            addemp.dob = DateTime.MinValue;
            addemp.loc = "";
            
            addemp.designation = "";
            addemp.doj = DateTime.MinValue;
            SucceedMsg = "New Employee added successfully";
            Response.Redirect("/Empinfo");


        }
    }
    public class addemp
    {
        public int id;
        public string name;
        public string designation;
        public DateTime  dob;
        public DateTime doj;
        public string loc;
    }

}
