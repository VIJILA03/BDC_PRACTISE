using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class checkuserbookModel : PageModel
    {

        public checkuserissue b = new checkuserissue();
        public string errorMsg = "";
        public string successMsg = "";
        public string Msg = "";
        public int days = 14;
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["Id"]);

            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "select BookId from BOOKS where BookId=@id";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        b.BookId = reader.GetInt32(0);


                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void OnPost()
        {
            Console.WriteLine(Request.Query["id"]);

            b.UserName = Request.Form["mailId"];
            b.BookId = Convert.ToInt32(Request.Query["id"]);
            b.IssuedDate = DateTime.Now;
            b.LastDate = b.IssuedDate.AddDays(14);
            if (b.BookId == 0 || b.UserName.Length == 0)
            {
                errorMsg = "All fields are mandatory";
                return;
            }
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("BookIssueInfo", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", b.UserName);
                cmd.Parameters.AddWithValue("@bid", b.BookId);
                cmd.Parameters.AddWithValue("@idate", b.IssuedDate);
                cmd.Parameters.AddWithValue("@rdate", b.LastDate);
                SqlDataReader dr = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            successMsg = " Book selected successfully";


        }
    }
    public class checkuserissue
    {

        public string UserName;
        public int BookId;
        public DateTime IssuedDate;
        public DateTime LastDate;


    }

}




