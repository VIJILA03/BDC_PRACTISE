using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace WebApplication1.Pages
{
    public class EmpinfoModel : PageModel
    {
        public List<Emp> listofemployees = new List<Emp>();

        public void OnGet()
        {
      
         
                try
                {
                    string connectionstring = "Data Source=LAPTOP-PH4JPVTP;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    SqlConnection sqlconn = new SqlConnection(connectionstring);
                    sqlconn.Open();
                    string QueryString = "select  * from EmpInfo";
                    SqlCommand cmd = new SqlCommand(QueryString, sqlconn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    Emp db = new Emp();
                    db.id = reader.GetInt32(0);
                    db.name = reader.GetString(1);
                    db.des = reader.GetString(2);
                    db.dob = reader.GetDateTime(3);
                    db.dobdate = db.dob.ToShortDateString();
                    db.dateofjoining = reader.GetDateTime(4);
                    db.dojdate = db.dateofjoining.ToShortDateString();
                    db.loc = reader.GetString(5);
                    listofemployees.Add(db);
                }
                }
                catch (Exception ex)
                {
                }
            }
            public class Emp
            {
            public int id;
            public string name;
            public string des;
            public DateTime dob;
            public DateTime dateofjoining;
            public string dobdate;
            public string dojdate;
            public string loc;
            }
        }
    }


