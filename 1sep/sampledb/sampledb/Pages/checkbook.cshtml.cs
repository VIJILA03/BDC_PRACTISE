using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace sampledb.Pages
{
    public class checkbookModel : PageModel
    {


        public checkbook chkbk = new checkbook();
        public string ErrorMsg = "";
        public string SucceedMsg = "";
        public void OnGet()
        {

            int id = Convert.ToInt32(Request.Query["Id"]);
            int availability = Convert.ToInt32(Request.Query["Availability"]);
            Console.WriteLine(id);

            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);
                sqlconn.Open();
                string QueryString = "select * from BookAvailability where Book_Id=@id";
                using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@availability",availability);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        chkbk.id = reader.GetInt32(0);
                        chkbk.name = reader.GetString(1);
                        chkbk.availability = reader.GetInt32(2);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void OnPost()
        {


            chkbk.id = Convert.ToInt32(Request.Query["Id"]);
            chkbk.availability = Convert.ToInt32(Request.Query["Availability"]);
            Console.WriteLine(chkbk.availability);
            if (chkbk.availability == 0)
            {
                ErrorMsg = "NO COPIES FOUND TRY LATER SOMETIME";
                return;
            }

            else
            {
                try
                {
                    string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    SqlConnection sqlconn = new SqlConnection(connectionstring);
                    sqlconn.Open();
                    string QueryString = "update Bookavailability set Available_books=Available_books-1 where Book_Id=@id and Available_books!=0";

                    using (SqlCommand cmd = new SqlCommand(QueryString, sqlconn))
                    {
                        cmd.Parameters.AddWithValue("@id", chkbk.id);
                        cmd.Parameters.AddWithValue("@available", chkbk.availability);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                SucceedMsg = " Booked successfully";
            }
        }
    }
        public class checkbook
        {
            public int id;
            public string name;
        public int availability;


    }
    }





  