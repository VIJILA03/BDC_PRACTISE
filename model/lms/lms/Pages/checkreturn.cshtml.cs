using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class checkreturnModel : PageModel
    {
        public List<checkbookissue> listofissue = new List<checkbookissue>();
        public void OnGet()
        {
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);

                sqlconn.Open();

                

                SqlCommand cmd = new SqlCommand("Exceed", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    checkbookissue db = new checkbookissue();

                    db.username = reader.GetString(0);
                    Console.WriteLine(db.username);
                    db.bookid = reader.GetInt32(1);

                    db.issuedate = reader.GetDateTime(2);
                    db.idatef = db.issuedate.ToString("yyyy/MM/dd HH:mm:ss");
                    db.returndate = reader.GetDateTime(3);
                    db.rdatef = db.returndate.ToString("yyyy/MM/dd HH:mm:ss");

                    listofissue.Add(db);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    public class checkbookissue
    {
        public string username;
        public int bookid;
        public DateTime issuedate;
        public DateTime returndate;
        public string idatef;
        public string rdatef;
    }
 
}
