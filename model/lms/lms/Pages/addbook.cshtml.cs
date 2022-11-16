using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class addbookModel : PageModel
    {

        public addbook ab= new addbook();
        public string ErrorMsg = "";
        public string SucceedMsg = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {

            ab.id = Convert.ToInt32(Request.Form["Id"]);
            Console.WriteLine(ab.id);
            ab.name = Request.Form["Name"];
            Console.WriteLine(ab.name);
            ab.author = Request.Form["Author"];
            Console.WriteLine(ab.author);
            ab.publication= Request.Form["Publication"];
            ab.copies = Convert.ToInt32(Request.Form["Copies"]);
            if (ab.id == 0 || ab.name.Length == 0 || ab.author.Length == 0 || ab.publication.Length == 0 ||
                  ab.copies == 0)
            {
                ErrorMsg = "All fields are required";
                return;
            }
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "insert into BOOKS values(@Id,@Name,@Author,@Publication,@Copies)";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@Id", ab.id);
                    cmd.Parameters.AddWithValue("@Name", ab.name);
                    cmd.Parameters.AddWithValue("@Author", ab.author);
                    cmd.Parameters.AddWithValue("@Publication", ab.publication);
                    cmd.Parameters.AddWithValue("@Copies", ab.copies);
                    cmd.ExecuteNonQuery();
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ab.id = 0;
            ab.name = "";
            ab.author = "";
            ab.publication = "";
            ab.copies = 0;

            SucceedMsg = "New Book added successfully";
            Response.Redirect("/books");


        }
    }
    public class addbook
    {
        public int id;
        public string name;
        public string author;
        public string publication;
        public int copies;
    }

}
