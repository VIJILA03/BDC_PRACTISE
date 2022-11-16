using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace lms.Pages
{
    public class IssuedBookModel : PageModel
    {
 public List<issuebk> listofissuedbook = new List<issuebk>();
        public void OnGet()
        {
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);

                sqlconn.Open();

                string QueryString = "select * from BookIssue";
                Console.WriteLine(QueryString);

                SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("after");
                while (reader.Read())
                {
                    issuebk db = new issuebk();
                    db.name = reader.GetString(0);
                    db.bid = reader.GetInt32(1);
                    db.issuedate = reader.GetDateTime(2);
                    db.idatef = db.issuedate.ToString("yyyy/MM/dd HH:mm:ss");
                    Console.WriteLine(db.idatef);
                    db.returndate = reader.GetDateTime(3);
                    db.rdatef = db.returndate.ToString("yyyy/MM/dd HH:mm:ss");


                    listofissuedbook.Add(db);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    public class issuebk
    {

        public int bid;
        public string rdatef;
        public DateTime returndate;
        public string idatef;
        public DateTime issuedate;
        public string name;



    }
}





