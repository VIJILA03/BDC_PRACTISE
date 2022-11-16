using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class accountinfoModel : PageModel
    {
       public  string name1;
        public List<accinfo> listofdet = new List<accinfo>();
        public void OnGet()
        {
            if (HttpContext.Session.GetString("Name") != null)
            {
                name1 = HttpContext.Session.GetString("Name");
            }
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);

                sqlconn.Open();

                string QueryString = "select Id,UserName,FirstName,LastName,PhoneNumber from AspNetUsers where UserName=@uname1";

                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                cmd.Parameters.Add("@uname1", System.Data.SqlDbType.VarChar).Value = name1;
                SqlDataReader reader = cmd.ExecuteReader();
                //cmd.Parameters.AddWithValue("@name", name);
              

                while (reader.Read())
                {
                    accinfo db = new accinfo();

                    //db.id = reader.GetInt32(0);
                    db.id = reader.GetString(0);
                    Console.WriteLine(db.id);
                    db.name = reader.GetString(1);
                    db.fname = reader.GetString(2);
                    db.lname = reader.GetString(3);
                    db.phn = reader.GetString(4);
                    Console.WriteLine(db.name);
                    listofdet.Add(db);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class accinfo
    {
        public string name;
        //public int id;
        public string id;
        public string fname;
        public string lname;
        public string phn;
    }
}




