using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace sampledb.Pages
{
    public class usercheckModel : PageModel
    {
        public List<USERINFO> listofusers = new List<USERINFO>();
        public void OnGet()
        {
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);

                sqlconn.Open();

                string QueryString = "select userid,username,noofbookstaken from bookuser";

                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    USERINFO db = new USERINFO();

                    db.id = reader.GetInt32(0);
                    db.name = reader.GetString(1);
                    Console.WriteLine(db.name);
                    db.bookstaken = reader.GetInt32(2);
                    listofusers.Add(db);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    public class USERINFO
    {
        
        public int id;
        public string name;
        public int bookstaken;
        public DateTime enddate;
    }
}