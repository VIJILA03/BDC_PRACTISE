using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class booksModel : PageModel
    {

 
        public List<books> listofbooks = new List<books>();
        public void OnGet()
        {
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);

                sqlconn.Open();

                string QueryString = "select * from BOOKS";

                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    books db = new books();

                    db.id = reader.GetInt32(0);
                    db.name = reader.GetString(1);
                    Console.WriteLine(db.name);
                    db.author = reader.GetString(2);
                    db.publication = reader.GetString(3);
                    db.copies = reader.GetInt32(4);
                    listofbooks.Add(db);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    public class books
    {
        public string name;
        public int id;
        public int copies;
        public string author;
        public string publication;
    }
}



