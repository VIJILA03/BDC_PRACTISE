using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class changereturnModel : PageModel
    {

        public changebook b = new changebook();
        public string errorMsg = "";
        public string successMsg = "";
        public string name1;
        public int count = 0;
        public void OnGet()
        {

            int bid = Convert.ToInt32(Request.Query["bid"]);
            //string username=Request.Query["username"];

            //DateTime returndate = Convert.ToDateTime(Request.Query["returndate"]);
            try
            {

                if (HttpContext.Session.GetString("Name") != null)
                {
                    name1 = HttpContext.Session.GetString("Name");
                }
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("Checkreturndate", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@uname1", System.Data.SqlDbType.VarChar).Value = name1;
                cmd.Parameters.AddWithValue("@bid", bid);

                // cmd.Parameters.AddWithValue("@returndate", returndate);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                    Console.WriteLine(count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void OnPost()
        {
            Console.WriteLine(Request.Query["bid"]);
            b.bid = Convert.ToInt32(Request.Query["bid"]);
            //b.username = Request.Query["username"];
            //b.returndate = Convert.ToDateTime(Request.Query["returndate"]);
            //b.returndate = b.returndate.AddDays(14);
            Console.WriteLine(b.bid);
            try
            {
                if (HttpContext.Session.GetString("Name") != null)
                {
                    name1 = HttpContext.Session.GetString("Name");
                }
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "UPDATE  BookIssue SET ReturnDate = DateAdd(day, 14, ReturnDate)  where BookId=@bid and UserName=@username";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    //cmd.Parameters.AddWithValue("@returndate", b.returndate);
                    cmd.Parameters.AddWithValue("@bid", b.bid);
                    cmd.Parameters.AddWithValue("@username", name1);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            b.bid = 0;
            successMsg = " Return date updated successfully";
            //Response.Redirect("/bookuser");
        }
        public class changebook
        {
            public int bid;
            public string username;
            public DateTime returndate;
        }


    }
}





