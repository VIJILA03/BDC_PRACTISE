using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class editbookModel : PageModel
    {
      
        public editbook eb = new editbook();
        public string errorMsg = "";
        public string successMsg = "";
        public void OnGet()
        {

            int id = Convert.ToInt32(Request.Query["Id"]);
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "select BookName,Author,Publication,TotalBooks from BOOKS where BookId=@id";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        eb.name = reader.GetString(0);
                        eb.author = reader.GetString(1);
                        eb.publication = reader.GetString(2);
                        eb.copies = reader.GetInt32(3);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void OnPost()
        {
            eb.id = Convert.ToInt32(Request.Query["Id"]);
            eb.name = Request.Form["Name"];
            eb.author = Request.Form["Author"];
            eb.publication = Request.Form["Publication"];
            eb.copies = Convert.ToInt32(Request.Form["Copies"]);
            if (eb.id == 0 || eb.name.Length == 0 || eb.author.Length == 0 ||
                eb.publication.Length == 0 || eb.copies == 0)

            {
                errorMsg = "All fields are mandatory";
                return;
            }



            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "Update Books set BookID=@id,BookName=@name,Author=@author,Publication=@publication,TotalBooks=@copies where BookId=@id";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@id", eb.id);
                    cmd.Parameters.AddWithValue("@name", eb.name);
                    cmd.Parameters.AddWithValue("@author", eb.author);
                    cmd.Parameters.AddWithValue("@publication", eb.publication);
                    cmd.Parameters.AddWithValue("@copies", eb.copies);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            eb.id = 0;
            eb.name = "";
            eb.author = "";
            eb.publication = "";
            eb.copies = 0;

            successMsg = "Changes saved successfully";

            Response.Redirect("/Books");


        }


        public class editbook
        {
            public int id;
            public string name;
            public string author;
            public string publication;
            public int copies;


        }


    }
}
