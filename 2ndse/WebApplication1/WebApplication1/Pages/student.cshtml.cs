using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace WebApplication1.Pages
{
    public class studentModel : PageModel
    {
        public List<StudentExam> listofstudents = new List<StudentExam>();
       
        public  void OnGet()
        {
           
            try
            {
                
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "select StdName,Marks,CourseName from StudentExam";
                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentExam db = new StudentExam();

                    db.name = reader.GetString(0);
                    //Console.WriteLine(db.name);
                    db.mark = reader.GetInt32(1);
                    db.course = reader.GetString(2);
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
        public int mark;
        public string course;
    }
}


