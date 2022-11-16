using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class userModel : PageModel
    {

        public List<users> listofusers = new List<users>();
        public void OnGet()
        {
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);

                sqlconn.Open();

                string QueryString = "select ID,FirstName,LastName,UserName,Email,PhoneNumber from AspNetUsers";
                Console.WriteLine(QueryString);

                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("after");
                while (reader.Read())
                {
                    users db = new users();

                    db.id = reader.GetString(0);
                    db.fname = reader.GetString(1);
                    db.lname = reader.GetString(2);
                    db.name = reader.GetString(3);
                    db.email = reader.GetString(4);
                    db.phone = reader.GetString(5);
                    listofusers.Add(db);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class users
    {

        public string id;
        public string email;
        public string fname;
        public string lname;
        public string name;
        public string phone;

        

    }
}




