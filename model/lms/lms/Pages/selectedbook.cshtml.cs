using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace lms.Pages
{
    public class selectedbookModel : PageModel
    {


        public string name1;
        public List<selectedbooks> listofslbooks = new List<selectedbooks>();
        public void OnGet()
        {
            if (HttpContext.Session.GetString("Name") != null)
            {
                name1 = HttpContext.Session.GetString("Name");
            }
            try
            {
                string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=LMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(connectionstring);

                sqlconn.Open();

                SqlCommand cmd = new SqlCommand("BookSelected", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@uname1", System.Data.SqlDbType.VarChar).Value = name1;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    selectedbooks db = new selectedbooks();
                    db.name = reader.GetString(0);
                    db.id = reader.GetInt32(1);
                  
                    Console.WriteLine(db.name);
                    db.bookname = reader.GetString(2);
                    db.idate = reader.GetDateTime(3);
                    db.idatef = db.idate.ToString("yyyy/MM/dd HH:mm:ss");
                    db.rdate = reader.GetDateTime(4);
                    db.rdatef = db.rdate.ToString("yyyy/MM/dd HH:mm:ss");
                    listofslbooks.Add(db);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class selectedbooks
    {
        public string name;
        public string idatef;
        public string rdatef;
        public int id;
        public string bookname;
        public DateTime idate;
        public DateTime rdate;
    }
}



