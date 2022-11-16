using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace sampledb.Pages
{
    public class studentModel : PageModel
    {
        public List<StudentExam> listofstudents = new List<StudentExam>();
        public void OnGet()
        {
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                
                sqlconn.Open();
                
                string QueryString = "select * from Bookavailability";
                
                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    StudentExam db = new StudentExam();

                    db.id = reader.GetInt32(0);
                    db.name= reader.GetString(1);
                    Console.WriteLine(db.name);
                    db.availability = reader.GetInt32(2);
                    listofstudents.Add(db);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    public class StudentExam
    {
    public string name;
    public int id;
    public int availability;
    }
}



