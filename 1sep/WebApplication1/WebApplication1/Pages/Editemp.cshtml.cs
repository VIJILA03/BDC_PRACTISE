using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace WebApplication1.Pages
{
    public class EditempModel : PageModel
    {
        public editemp edemp = new editemp();
        public string ErrorMsg = "";
        public string SucceedMsg = "";
        public void OnGet()
        {

            int id = Convert.ToInt32(Request.Query["Id"]);
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "select EmpName,Designation,BaseLocation from EmpInfo where EmpId=@id";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        edemp.name = reader.GetString(0);
                        edemp.des = reader.GetString(1);
                        edemp.loc = reader.GetString(2);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void OnPost()
        {

            Console.Write("HELLO" + (Request.Query["Id"]));
            edemp.id= Convert.ToInt32(Request.Query["Id"]);
            edemp.name = Request.Form["Name"];
            edemp.des = Request.Form["Designation"];
            edemp.loc = Request.Form["BaseLocation"];
            if (edemp.name.Length == 0 || edemp.des.Length == 0 || edemp.loc.Length == 0)
            {
                ErrorMsg = "All fields are required";
                return;
            }
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "update EmpInfo set EmpName=@name,Designation=@des,BaseLocation=@loc where EmpId=@id";
                
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@name", edemp.name);
                    cmd.Parameters.AddWithValue("@des", edemp.des);
                    cmd.Parameters.AddWithValue("@loc", edemp.loc);
                    cmd.Parameters.AddWithValue("@id",edemp.id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            edemp.name = "";
            edemp.loc = "";
            edemp.des = "";
            SucceedMsg = " Employee updated successfully";
            Response.Redirect("/Empinfo");
        }
    }
    public class editemp
        {
            public int id;
            public string name;
            public string des;
            public string loc;

        }
    }




