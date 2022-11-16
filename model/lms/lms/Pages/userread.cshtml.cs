using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class userreadModel : PageModel
    {
        public int id;
        public string name1;
        public int count = 0;
        //private string message = string.Empty;
        public void OnGet()
        {
            try
            {

                id = Convert.ToInt32(Request.Query["bid"]);
                if (HttpContext.Session.GetString("Name") != null)
                {
                    name1 = HttpContext.Session.GetString("Name");
                }
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("Bookread", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@bid", id);

                cmd.Parameters.Add("@error", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                // read output value from @NewId
                count = Convert.ToInt32(cmd.Parameters["@error"].Value);

                Console.WriteLine("already" + count);
                // cmd.Parameters.AddWithValue("@returndate", returndate);
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


