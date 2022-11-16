using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class BookIssueModel : PageModel
    {

        public issuebook b = new issuebook();
        public string errorMsg = "";
        public string successMsg = "";
        public string Msg = "";
        public string name1;
        public int id;
        public int count = 0;
        public int count1 = 0;
        public int count2 = 0;
        public void OnGet()
        {
            id = Convert.ToInt32(Request.Query["Id"]);

            try
            {
                if (HttpContext.Session.GetString("Name") != null)
                {
                    name1 = HttpContext.Session.GetString("Name");
                }

                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                //string QueryString = "select count(UserName) from BookIssue where UserName=@uname1";

                //SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlCommand cmd = new SqlCommand("checkuser", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@uname1", System.Data.SqlDbType.VarChar).Value = name1;
                Console.WriteLine(name1);
                cmd.Parameters.AddWithValue("@bid", id);
                //cmd.Parameters.AddWithValue("@bid", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                    count1 = reader.GetInt32(1);
                    Console.WriteLine(count);
                    Console.WriteLine(count1);


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void OnPost()
        {
            Console.WriteLine(Request.Query["id"]);


            id = Convert.ToInt32(Request.Query["id"]);
            b.IssuedDate = DateTime.Now;
            b.LastDate = b.IssuedDate.AddDays(14);
            if (id == 0)
            {
                errorMsg = "All fields are mandatory";
                return;
            }
            try
            {
                if (HttpContext.Session.GetString("Name") != null)
                {
                    name1 = HttpContext.Session.GetString("Name");
                }
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();

                using (SqlCommand cmd = new SqlCommand("BookIssueInfo", sqlconn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@uid", System.Data.SqlDbType.VarChar).Value = name1;
                    cmd.Parameters.AddWithValue("@uid", name1);
                    Console.WriteLine(name1);
                    cmd.Parameters.AddWithValue("@bid", id);
                    cmd.Parameters.AddWithValue("@idate", b.IssuedDate);
                    cmd.Parameters.AddWithValue("@rdate", b.LastDate);
                    //cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count2 = reader.GetInt32(0);
                       
                        Console.WriteLine(count2);
                       


                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            successMsg = " Book selected successfully";
            //Response.WriteAsync(successMsg).Wait();
            //Response.Redirect("/selectedbook");




        }

        public class issuebook
        {

            public string UserName;
            public int BookId;
            public DateTime IssuedDate;
            public DateTime LastDate;


        }

    }
}



