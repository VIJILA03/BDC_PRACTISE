using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace WebApplication1.Pages
{
    public class BooksModel : PageModel
    {
        public List<Books> ListOfBooks = new List<Books>();

        public void OnGet()
        {


            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "select  * from Bookavailability";
                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Books db = new Books();
                    db.id = reader.GetInt32(0);
                    db.name = reader.GetString(1);
                    db.availability = reader.GetInt32(3);
                    ListOfBooks.Add(db);
                }
            }
            catch (Exception)
            {
            }
        }
        public class Books
        {
            public int id;
            public string name;
            public int availability;

        }
    }
}



